using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyZone : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    private SphereCollider _collider;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        var percentProgressed = levelManager.MaxMissionTime - levelManager.RemainingMissionTime;
        var percentage = percentProgressed / levelManager.MaxMissionTime;
        var scaleFactor = 1 - percentage;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
