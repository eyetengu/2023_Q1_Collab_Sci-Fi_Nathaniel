using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets
{
    public class Foosball_Ball : MonoBehaviour
    {
        Rigidbody _rigidbody;
        [SerializeField] Transform _ballResetPoint;
        [SerializeField] float _kickforce = 3.0f;


    //BUILT-IN FUNCTIONS
        private void OnEnable()
        {
            Foosball_UI_Manager.resetBall += ResetBallAtStartPosition;
        }

        private void OnDisable()
        {
            Foosball_UI_Manager.resetBall -= ResetBallAtStartPosition;
        }

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (transform.position.y < -5.0f)
                ResetBallAtStartPosition();
        }


    //CORE FUNCTIONS
        void ResetBallAtStartPosition()
        {
            transform.position = _ballResetPoint.position;
            _rigidbody.AddForce(Vector3.one, ForceMode.Acceleration);
            _rigidbody.AddTorque(new Vector3(2, 0, .25f), ForceMode.Impulse);
        }


    //COLLISION FUNCTIONS
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "FoosPlayer")
            {
                Debug.Log("Ball Is Kicked");
                
                _rigidbody.AddForceAtPosition(collision.transform.position, collision.contacts[0].normal * _kickforce, ForceMode.Impulse);
            }
        }
    }
}