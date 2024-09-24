using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_KeyInventory : MonoBehaviour
{
    [SerializeField] public List<string> _keys = new List<string>();
    

    public void AddKeyToKeyring(string keyName)
    {
        _keys.Add(keyName);
    }

    public void RemoveKeyFromKeyring(string keyName)
    {
        _keys.Remove(keyName);
    }
}
