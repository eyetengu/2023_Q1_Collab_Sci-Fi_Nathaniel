using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbacusGameManager", menuName = "ScriptableObjects/AbacusGameManager", order = 1)]
public class AbacusGameManager : ScriptableObject
{
    public string PlayerName { get; set; }
}
