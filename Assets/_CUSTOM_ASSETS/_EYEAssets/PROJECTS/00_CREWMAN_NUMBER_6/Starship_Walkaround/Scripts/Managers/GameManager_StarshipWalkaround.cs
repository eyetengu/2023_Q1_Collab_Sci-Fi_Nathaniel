using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_StarshipWalkaround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CursorLockAndHide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void CursorConfineAndShow()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void CursorConfineAndHide()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void CursorLockAndShow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void CursorLockAndHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }




}
