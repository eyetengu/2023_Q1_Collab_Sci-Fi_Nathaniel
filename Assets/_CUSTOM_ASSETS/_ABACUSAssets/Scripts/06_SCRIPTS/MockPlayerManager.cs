using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockPlayerManager : MonoBehaviour
{
    [SerializeField] private string _name = string.Empty;

    public string Name { get { return _name; } }

    public void SetName(string name)
    {
        _name = name;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
