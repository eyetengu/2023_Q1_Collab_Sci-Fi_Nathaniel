using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox_Enemy_Appearance : MonoBehaviour
{
    MeshRenderer _renderer;
    [SerializeField] Material[] _cleanColor;
    [SerializeField] Material[] _dirtyColor;
    int _colorID;

    bool _cleanVehicle;


//BUILT-IN FUNCTIONS
    void Start()
    {
        ShowCurrentPaintColor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectAndDisplayCurrentPaintJob();

        if (Input.GetKeyDown(KeyCode.Alpha6))
            ChangeDirty();
    }


//CORE FUNCTIONS
    void SelectAndDisplayCurrentPaintJob()
    {
        SelectNextPaintJob();
        ShowCurrentPaintColor();
    }

    void SelectNextPaintJob()
    {
        _colorID++;
        if (_colorID > _cleanColor.Length - 1) 
            _colorID = 0;
    }

    public void ShowCurrentPaintColor()
    {
        _renderer = GetComponentInChildren<MeshRenderer>();
        if (_cleanVehicle)
            _renderer.material = _dirtyColor[_colorID];
        else
            _renderer.material = _cleanColor[_colorID];
    }

    void ChangeDirty()
    {
        _cleanVehicle = !_cleanVehicle;
        ShowCurrentPaintColor();
    }
}
