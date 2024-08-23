using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager_StarshipWalkAround : MonoBehaviour
{
    [SerializeField] GameObject _startScreen;
    [SerializeField] GameObject _instructionPanel;


    [Header("GENEX VALUES")]
    [SerializeField] TMP_Text _experienceValue;
    [SerializeField] TMP_Text _goldValue;
    [SerializeField] TMP_Text _healthValue;
    [SerializeField] TMP_Text _scoreValue;

    [SerializeField] TMP_Text _inventoryList;

//BUILT-IN FUNCTIONS
    void Start()
    {
        _startScreen.SetActive(true);
        _instructionPanel.SetActive(false);
        StartCoroutine(TitleScreenTimer());
    }

    void Update()
    {
        
    }

//Display Values
    public void DisplayScore(int score)
    {
        _scoreValue.text = score.ToString();
    }

    public void DisplayExperience(int experience)
    {
        _experienceValue.text = experience.ToString();
    }

    public void DisplayGold(int gold)
    {
        _goldValue.text = gold.ToString();
    }

    public void DisplayHealth(int health)
    {
        _healthValue.text = health.ToString();
    }


    public void ShowInventoryItems(List<GameObject> items)
    {
        _inventoryList.text = "";
        foreach(var item in items)
            _inventoryList.text += item.name + "\n";
    
        
    }














    IEnumerator TitleScreenTimer()
    {
        yield return new WaitForSeconds(2.0f);
        _instructionPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        _startScreen.SetActive(false);
        _instructionPanel.SetActive(false);
    }

}
