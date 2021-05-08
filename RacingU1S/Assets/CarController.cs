using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] WheelsCol;
    public Transform[] WheelsMesh;

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxBrakePower;

    public timerController gui;


    // Start is called before the first frame update
    private void Start()
    {
        for( int i=0; i< WheelsCol.Length; i++){
            WheelsCol[i].transform.position = WheelsMesh[i].position;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float brake = maxBrakePower * 5;

        WheelsCol[0].steerAngle = steering;
        WheelsCol[1].steerAngle = steering;

        if(Input.GetKey("space"))
        {
            WheelsCol[0].motorTorque = 0;
            WheelsCol[1].motorTorque = 0;
            WheelsCol[0].brakeTorque = brake;
            WheelsCol[1].brakeTorque = brake;


        }else{
            WheelsCol[0].motorTorque = motor;
            WheelsCol[1].motorTorque = motor;
            WheelsCol[0].brakeTorque = 0;
            WheelsCol[1].brakeTorque = 0;
        }
        for(int i= 0 ; i<WheelsMesh.Length; i++){
            Vector3 p;
            Quaternion q;

            WheelsCol[i].GetWorldPose(out p, out q);

            WheelsMesh[i].position = p;
            WheelsMesh[i].rotation = q;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            if(gui.timer <= gui.bestTimer)
            {
                gui.bestTimer = gui.timer;
            }
            gui.startTime = Time.time;
        }
    }
}
