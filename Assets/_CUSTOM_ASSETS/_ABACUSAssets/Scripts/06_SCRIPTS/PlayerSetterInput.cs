using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetterInput : MonoBehaviour
{
    MockPlayerManager mockPlayerManager;
    // Start is called before the first frame update
    void Start()
    {
        mockPlayerManager = FindFirstObjectByType<MockPlayerManager>();
        if (mockPlayerManager == null )
        {
            Debug.LogError("MockPlayerManager not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateName(string name)
    {
        if (mockPlayerManager != null)
        {
           mockPlayerManager.SetName(name + "test");
        }
    }
}
