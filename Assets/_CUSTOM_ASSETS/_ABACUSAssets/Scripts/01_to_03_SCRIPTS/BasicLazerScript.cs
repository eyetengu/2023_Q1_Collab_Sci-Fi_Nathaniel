using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicLazerScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int _damage = 10;
    public int Damage { get => _damage; }
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        CheckCameraViewPortBeforeDestroy();
    }

    private void CalculateMovement()
    {
        var moveDirection = Vector3.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
    }

    private void CheckCameraViewPortBeforeDestroy()
    {
        var screenCoordinate = _camera.WorldToScreenPoint(transform.position);
        if (screenCoordinate.x > _camera.pixelWidth || screenCoordinate.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
