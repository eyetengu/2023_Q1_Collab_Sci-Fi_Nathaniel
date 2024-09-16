using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RAYCAST_PickUp_PutDown : MonoBehaviour
{
    [SerializeField] Camera _playerCam;
    [SerializeField] int xPos = 335;
    [SerializeField] int yPos = 600;

    MeshRenderer _renderer;
    Material _oldRenderMaterial;
    [SerializeField] Material _newRenderMaterial;
    AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] Transform _zoneOfPower;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //var mousePos = Mouse.current.position;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(xPos, yPos, 0));
        Debug.Log(Screen.height + "/" + Screen.width);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var objectTransform = hitInfo.transform;
            var objectName = objectTransform.name;
            _renderer = objectTransform.GetComponent<MeshRenderer>();
            Debug.Log(objectName);

            if (Input.GetKey(KeyCode.E) && hitInfo.transform.name != "Ground")
            {
                objectTransform.SetParent(_zoneOfPower, false);
                objectTransform.position = _zoneOfPower.position;
                objectTransform.rotation = _zoneOfPower.rotation;

                _oldRenderMaterial = _renderer.material;
                _renderer.material = _newRenderMaterial;
                _audioSource.PlayOneShot(_audioClip);
            }
            else if (Input.GetKeyUp(KeyCode.E) && hitInfo.transform.name != "Ground")
            {
                if (_renderer != null)
                {
                    _renderer.material = _oldRenderMaterial;
                    objectTransform.position = Vector3.zero;
                    objectTransform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
        }
    }
}
