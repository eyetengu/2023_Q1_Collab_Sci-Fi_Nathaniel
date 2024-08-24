using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class SpaceDialogManager : MonoBehaviour
{
    private string[] lines;
    private int index;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        
        if (displayText == null)
        {
            Debug.LogError($"Missing Text Component for {nameof(displayText)}");
        }
        displayText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (displayText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                displayText.text = lines[index];
            }
        }
    }

    public void StartDialog(IEnumerable<string> linesToDisplay)
    {
        lines = linesToDisplay.ToArray();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {

            displayText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            displayText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
