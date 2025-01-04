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
    private float currentTorque = 0;
	

    private void Start()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            // create wheel shapes only when needed
            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }

    private void Update()
    {
        float angle = maxAngle * Input.GetAxis("Horizontal");
        float inputTorque = maxTorque * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBraking = !isBraking;
        }

        if (isBraking)
            currentTorque = Mathf.Lerp(currentTorque, 0, brakeSmoothTime * Time.deltaTime);
        else
            currentTorque = Mathf.Lerp(currentTorque, inputTorque, brakeSmoothTime * Time.deltaTime);

        foreach (var wheel in wheels)
        {
            // A simple car where front wheels steer while rear ones drive
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
            {
                if (isBraking)
                    wheel.brakeTorque = brakeTorque;
                else
                    wheel.motorTorque = currentTorque;
                wheel.brakeTorque = isBraking ? brakeTorque : 0;
            }

            // Update visual wheels if any
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // Assume that the only child of the wheel collider is the wheel shape
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;
                shapeTransform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
