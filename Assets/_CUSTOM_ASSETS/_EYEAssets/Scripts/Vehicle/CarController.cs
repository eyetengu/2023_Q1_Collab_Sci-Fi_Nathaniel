using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;

        public bool motor;
        public bool steering;

    }
    public List<AxleInfo> _axlesInfo = new List<AxleInfo>();
    public List<Transform> _allWheels = new List<Transform>();

    public float maxMotorTorque;
    public float maxSteeringAngle;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");   

        foreach(AxleInfo axleInfo in _axlesInfo)
        {
            if(axleInfo.steering == true)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if(axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            SpinWheels(axleInfo.leftWheel);
            SpinWheels(axleInfo.rightWheel);
        }
    }

    void SpinWheels(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
            return;

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;  
    }
}
