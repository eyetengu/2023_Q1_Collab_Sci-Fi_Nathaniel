using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntroMessage_Behavior : MonoBehaviour
{
    [SerializeField] GameObject[] _messages;

    
    void Start()
    {
        CloseAllMessages();
        StartCoroutine(IntroMessageTimer());   
    }

    void CloseAllMessages()
    {
        foreach (GameObject message in _messages)        
            message.SetActive(false);        
    }
    
    IEnumerator IntroMessageTimer()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i <= _messages.Length - 1; i++)
        {
            _messages[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);            
        }

        yield return new WaitForSeconds(4.0f);

        foreach (var message in _messages)
            CloseAllMessages();
    }
}
