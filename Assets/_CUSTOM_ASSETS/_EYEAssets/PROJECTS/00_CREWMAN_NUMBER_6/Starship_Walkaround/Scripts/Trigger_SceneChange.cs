using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_SceneChange : MonoBehaviour
{
    [SerializeField] int _sceneToLoad;
    [SerializeField] GameObject _fxObject;
    [SerializeField] bool _activateFX;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_activateFX)
            {
                _fxObject.SetActive(true);
                StartCoroutine(ReturnToNormal());
            }
            else
                SceneManager.LoadScene(_sceneToLoad);

        }
    }

    IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(2.0f);
        _fxObject.SetActive(false);
        SceneManager.LoadScene(_sceneToLoad);
    }
}
