using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOutfit : MonoBehaviour
{
    MeshRenderer _meshRenderer;

    [SerializeField] List<GameObject> _bodyTypes;
    [SerializeField] List<Material> _paintJobs;


    void Start()
    {
        SwapBodyStyle();

        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        SwapPaintJob();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SwapPaintJob();

        if (Input.GetKeyDown(KeyCode.M))
            SwapBodyStyle();
    }

    void SwapPaintJob()
    {
        _meshRenderer.material = _paintJobs[Random.Range(0, _paintJobs.Count)];        
    }

    void SwapBodyStyle()
    {

            foreach(GameObject type in _bodyTypes)
            {
                type.SetActive(false);
            }
            _bodyTypes[Random.Range(0, _bodyTypes.Count)].SetActive(true);
      
    }
}
