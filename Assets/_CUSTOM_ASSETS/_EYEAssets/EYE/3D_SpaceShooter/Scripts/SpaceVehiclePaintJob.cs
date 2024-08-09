using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceVehiclePaintJob : MonoBehaviour
{
    [SerializeField] List<Material> materials;
    MeshRenderer _renderer;

    void Start()
    {
        _renderer= GetComponent<MeshRenderer>();

        _renderer.material = materials[Random.Range(0, materials.Count-1)];
    }

}
