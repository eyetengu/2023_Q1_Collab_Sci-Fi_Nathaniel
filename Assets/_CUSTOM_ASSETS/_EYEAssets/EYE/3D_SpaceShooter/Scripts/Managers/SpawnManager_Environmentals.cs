using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Environmentals : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidFields;
    [SerializeField] private GameObject[] _hulkingCraft;

    float _fieldStep;
    [SerializeField] float _fieldSpeed = 5;
    [SerializeField] float _hulkingCraftSpeed = 1;

    private void Update()
    {
        _fieldStep = _fieldSpeed * Time.deltaTime;

        ScrollAsteroidField();
    }

    void ScrollAsteroidField()
    {
        foreach(var field in asteroidFields)
        {
            field.transform.position += new Vector3(0, 0, _fieldStep);

            if (field.transform.position.z <= -35)
                field.transform.position = new Vector3(0, 0, 35);
        }

        foreach(var craft in _hulkingCraft)
        {
            craft.transform.position += new Vector3(0, 0, _hulkingCraftSpeed * Time.deltaTime);

            if (craft.transform.position.z <= -150)
                craft.transform.position = new Vector3(0, 0, 150f);
        }
    }
}
