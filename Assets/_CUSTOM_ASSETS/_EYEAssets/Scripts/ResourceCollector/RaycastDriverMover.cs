using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastDriverMover : MonoBehaviour
{
    [SerializeField] private RaycastPlayer _player;

    private void Start()
    {
        _player = FindObjectOfType<RaycastPlayer>();
        if (_player == null)
        { Debug.Log("Player Not Found"); }
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider.name == "Floor")
                {
                    _player.UpdateDestination(hitInfo.point);
                    Debug.Log(hitInfo.point.ToString());
                }
            }
        }
    }
}

