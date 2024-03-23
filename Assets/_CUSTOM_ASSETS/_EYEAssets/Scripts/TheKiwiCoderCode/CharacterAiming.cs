using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float aimDuration = 0.3f;
    bool aimLayer;

    Camera mainCamera;
    RaycastWeapon _weapon;
    
    void Start()
    {
        mainCamera = Camera.main;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _weapon = GetComponentInChildren<RaycastWeapon>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if(aimLayer)
        {
            if(Input.GetButton("Fire2"))
            {
                //aimLayer.weight += Time.deltaTime / aimDuration;
            }
            else
            {
                //aimLayer.weight -= Time.deltaTime / aimDuration;
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _weapon.StartFiring();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            _weapon.StopFiring();
        }
    }
}
