using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicLazerScript : MonoBehaviour
{
    public float bulletSpeed;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        var moveDirection = Vector3.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
        var screenCoordinate = _camera.WorldToScreenPoint(transform.position);
        if (screenCoordinate.x > _camera.pixelWidth || screenCoordinate.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
