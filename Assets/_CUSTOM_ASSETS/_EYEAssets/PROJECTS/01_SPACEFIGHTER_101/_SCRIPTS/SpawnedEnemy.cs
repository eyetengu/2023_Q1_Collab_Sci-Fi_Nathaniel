using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnedEnemy : MonoBehaviour
{
    [SerializeField] float _lifeDuration;
    [SerializeField] Enemy_Spawner _spawner;
    [SerializeField] Transform _destination;


    void Start()
    {
        _destination = GameObject.Find("Target").GetComponent<Transform>();
        _spawner = FindObjectOfType<Enemy_Spawner>();

        StartCoroutine(LifeSpan());
        transform.Rotate(0, 90, 0);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination.position, 2.0f * Time.deltaTime);
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(_lifeDuration);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        _spawner.ReduceEnemyCount();
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Target")
        {
            Debug.Log("Boo");
            _spawner.ReduceEnemyCount();
            Destroy(gameObject);
        }

    }
}
