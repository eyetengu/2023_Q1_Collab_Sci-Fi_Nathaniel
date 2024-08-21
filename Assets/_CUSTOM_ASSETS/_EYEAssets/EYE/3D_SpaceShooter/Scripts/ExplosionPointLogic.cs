using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPointLogic : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float force = 15;
    [SerializeField] Vector3 position;
    [SerializeField] float radius = 10;

    [SerializeField] Rigidbody[] collisionObjects;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        position = transform.position;

        _rb.AddExplosionForce(force, position, radius);

        StartCoroutine(EndMovementTimer());
    }
    IEnumerator EndMovementTimer()
    {
        yield return new WaitForSeconds(1.0f);
        foreach(var item in collisionObjects)
        {
            item.drag = 0.1f;
            //item.isKinematic = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
