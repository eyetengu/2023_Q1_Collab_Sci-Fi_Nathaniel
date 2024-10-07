using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSActivator : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    public void ActivateGameObject() {  target.SetActive(true); }
}
