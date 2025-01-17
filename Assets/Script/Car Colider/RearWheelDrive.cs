using Unity.VisualScripting;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    public float maxAngle = 30;
    public float maxTorque = 900; 
    public float brakeTorque = 1000; 
    public float brakeSmoothTime = 0.3f; 
    public GameObject wheelShape;

    private WheelCollider[] wheels;
    public static bool isBraking = false;
    public static bool isStop = false;
    public static float currentTorque = 0;
	

    private void Start()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }

    private void Update()
    {
        var angle = maxAngle * Input.GetAxis("Horizontal");
        var inputTorque = maxTorque * Input.GetAxis("Vertical");

        var drivingMove = DrivingUI.GetCurrentSprite();

        if (Input.GetKeyDown(KeyCode.Space))
            isBraking = !isBraking;

        if (Input.GetKey(KeyCode.S))
            isStop = true;
        else
            isStop = false;

        if (isBraking || isStop)
            currentTorque = Mathf.Lerp(currentTorque, 0, brakeSmoothTime * Time.deltaTime);
        else if (drivingMove == 'D')
            currentTorque = Mathf.Lerp(currentTorque, inputTorque, brakeSmoothTime * Time.deltaTime);
        else if (drivingMove == 'R')
            currentTorque = Mathf.Lerp(currentTorque, -inputTorque, brakeSmoothTime * Time.deltaTime);

        foreach (var wheel in wheels)
        {
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
            {
                if (isBraking || isStop)
                    wheel.brakeTorque = brakeTorque;
                else
                    wheel.motorTorque = currentTorque;
                wheel.brakeTorque = isBraking || isStop ? brakeTorque : 0;
            }

            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;
                shapeTransform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
