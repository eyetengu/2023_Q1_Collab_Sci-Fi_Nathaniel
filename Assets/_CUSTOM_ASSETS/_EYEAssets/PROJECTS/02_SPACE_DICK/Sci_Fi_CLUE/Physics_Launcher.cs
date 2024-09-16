using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_Launcher : MonoBehaviour
{
    [SerializeField] Transform _barrel;
    [SerializeField] GameObject _cannonballPrefab;
    [SerializeField] float _projectileSpeed = 1000;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ball = Instantiate(_cannonballPrefab, _barrel.transform.position, _cannonballPrefab.transform.rotation = _barrel.transform.rotation);
            ball.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0,0,_projectileSpeed),new Vector3 (0, 0, -0.5f));
        }

        MoveCannon();
    }

    void MoveCannon()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontal * Time.deltaTime, 0, 0);
    }
}
