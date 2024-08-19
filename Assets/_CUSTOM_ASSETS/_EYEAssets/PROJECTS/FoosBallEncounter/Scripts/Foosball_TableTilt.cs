using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets
{
    public class Foosball_TableTilt : MonoBehaviour
    {
        Transform _tableFulcrum;

        [SerializeField] bool _rotateLat;
        [SerializeField] bool _rotateLong;
        [SerializeField] float _rotationSpeed = .1f;


        //BUILT-IN FUNCTIONS
        void Start()
        {
            _tableFulcrum = transform;
        }


        void Update()
        {
            if (_rotateLat)
                RotateLatituninally();
            if (_rotateLong)
                RotateLongitudinally();
        }


        //CORE FUNCTIONS
        void RotateLatituninally()
        {
            _tableFulcrum.Rotate(0, 0, _rotationSpeed);
        }

        void RotateLongitudinally()
        {
            _tableFulcrum.Rotate(_rotationSpeed, 0, 0);
        }





    }
}
