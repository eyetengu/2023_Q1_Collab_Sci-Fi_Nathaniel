using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLazerScript : MonoBehaviour
{
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        var moveDirection = Vector3.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
    }
}
