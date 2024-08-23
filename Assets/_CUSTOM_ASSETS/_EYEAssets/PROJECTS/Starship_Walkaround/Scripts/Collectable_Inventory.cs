using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player_Inventory _inventory = other.GetComponent<Player_Inventory>();
            if(_inventory != null)
            {
                _inventory.PassItemToInventory(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
