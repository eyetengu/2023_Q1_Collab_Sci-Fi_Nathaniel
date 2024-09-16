using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Command_UserClick : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        //left click
        //cast a ray
        //detect a cube
        //assign a random color

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayorigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayorigin, out hitInfo))
            {
                if (hitInfo.collider.tag == "Cube")
                {
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                    Command_Manager.Instance.AddCommands(click);
                }
            }
        }
    }
}
