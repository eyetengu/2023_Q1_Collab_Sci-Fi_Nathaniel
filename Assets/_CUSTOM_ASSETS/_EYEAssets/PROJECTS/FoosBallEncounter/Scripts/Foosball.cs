using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets 
{
    public class Foosball : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] Foosball_UI_Manager _uiManager;

        [Header("CHARACTER ANIMATION CONTROLS")]
        [SerializeField] Foosball_Team_Animation_Control _team_Blue;
        [SerializeField] Foosball_Team_Animation_Control _team_Red;

        [Header("ROTATORS")]
        [SerializeField] bool _threeRotators;
        [SerializeField] float _rotationSpeed = 5.0f;

        [Header("BLUE TEAM ROTATORS")]
        [SerializeField] Transform _rotator_01_Blue;
        [SerializeField] Transform _rotator_02_Blue;
        [SerializeField] Transform _rotator_03_Blue;

        [Header("RED TEAM ROTATORS")]
        [SerializeField] Transform _rotator_01_Red;
        [SerializeField] Transform _rotator_02_Red;
        [SerializeField] Transform _rotator_03_Red;

        [Header("MOVE VALUES")]
        [SerializeField] float _moveMultiplier = 1.5f;
        [SerializeField] float _maxMoveValue = 1.5f;
        Transform _currentRotator_Red;
        Transform _currentRotator_Blue;

        [Header("TABLE FEATURES")]
        [SerializeField] Transform _centerReset;
        [SerializeField] Vector3 _originalBumpPosition = new Vector3(0, -1, 0);

        [Header("FOOS BALL")]
        [SerializeField] Rigidbody _ballBody;
        bool _canBump;
        float _speedMultiplier = 5.0f;


    //BUILT-IN FUNCTIONS
        void Start()
        {
            _ballBody.AddExplosionForce(5.0f, new Vector3(0, 0, 1), .5f);
            _canBump = true;
            _currentRotator_Red = _rotator_01_Red;
            _currentRotator_Blue = _rotator_01_Blue;

            _team_Blue.SetAnimators(1, true);
            _team_Red.SetAnimators(1, true);
        }

        void Update()
        {
        //QUIT APPLICATION
            //if (Input.GetKeyDown(KeyCode.Escape))
                //Application.Quit();

        //Blue Team Controls
            Blue_Team_Inputs();

        //Red Team Controls
            Red_Team_Inputs();
        }

        void Blue_Team_Inputs()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentRotator_Blue = _rotator_01_Blue;
                _team_Blue.SetAnimators(1, true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentRotator_Blue = _rotator_02_Blue;
                _team_Blue.SetAnimators(2, true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && _threeRotators)
            {
                _currentRotator_Blue = _rotator_03_Blue;
                _team_Blue.SetAnimators(3, true);
            }

            RotateRotator_Blue();

        }

        void Red_Team_Inputs()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                _currentRotator_Red = _rotator_01_Red;
                _team_Red.SetAnimators(1, true);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                _currentRotator_Red = _rotator_02_Red;
                _team_Red.SetAnimators(2, true);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) && _threeRotators)
            {
                _currentRotator_Red = _rotator_03_Red;
                _team_Red.SetAnimators(3, true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && _canBump)
                BumpCenterReset();

            RotateRotator_Red();
        }

    //CORE FUNCTIONS
        void RotateRotator_Blue()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(0, vertical, 0);
            Vector3 velocity = direction * _moveMultiplier * 5 * Time.deltaTime;

            _currentRotator_Blue.transform.Rotate(0, horizontal * _rotationSpeed, 0);

            _currentRotator_Blue.transform.Translate(velocity);
            if (_currentRotator_Blue.position.x > _maxMoveValue)
                _currentRotator_Blue.position = new Vector3(_maxMoveValue, _currentRotator_Blue.position.y, _currentRotator_Blue.position.z);
            else if (_currentRotator_Blue.position.x < -_maxMoveValue)
                _currentRotator_Blue.position = new Vector3(-_maxMoveValue, _currentRotator_Blue.position.y, _currentRotator_Blue.position.z);
        }

        void RotateRotator_Red()
        {
            float horizontal = Input.GetAxis("Horizontal_01");
            float vertical = Input.GetAxis("Vertical_01");

            Vector3 direction = new Vector3(0, -vertical, 0);
            Vector3 velocity = direction * _moveMultiplier * 5 * Time.deltaTime;

            _currentRotator_Red.transform.Rotate(0, -horizontal * _rotationSpeed, 0);

            _currentRotator_Red.transform.Translate(velocity);
            if (_currentRotator_Red.position.x > _maxMoveValue)
                _currentRotator_Red.position = new Vector3(_maxMoveValue, _currentRotator_Red.position.y, _currentRotator_Red.position.z);
            else if (_currentRotator_Red.position.x < -_maxMoveValue)
                _currentRotator_Red.position = new Vector3(-_maxMoveValue, _currentRotator_Red.position.y, _currentRotator_Red.position.z);
        }

        void BumpCenterReset()
        {
            _canBump = false;
            StartCoroutine(CanBumpReset());
            _centerReset.transform.position = Vector3.zero;
            StartCoroutine(BumpTimer());
        }


    //COROUTINES
        IEnumerator BumpTimer()
        {
            yield return new WaitForSeconds(.15f);
            _centerReset.transform.position = _originalBumpPosition;
        }

        IEnumerator CanBumpReset()
        {
            _uiManager.UpdatePlayerMessage("");

            yield return new WaitForSeconds(4.0f);
            _canBump = true;
            _uiManager.UpdatePlayerMessage("Bump Available");
        }
    }
}