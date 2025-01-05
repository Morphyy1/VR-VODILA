using UnityEngine;


public class Trigger : MonoBehaviour
{
    private Vector3 CurrentPos = new Vector3(-1.38f, 1.772f, -139.57f);
    private Vector3 CurrentAngle = new Vector3(0, 90, 0);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Conus")
            IsPlayesCollision(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Snake":
                SetCurrentPosition(69.02f, 1.772f, -123.97f);
                break;  
            case "Rotation 1":
                SetCurrentPosition(121.41f, 1.772f, -150.29f);
                SetCurrentAngle(0, 180, 0);
                break;
            case "Rotation 2":
                SetCurrentPosition(83.85f, 1.772f, -152.02f);
                SetCurrentAngle(0, 0, 0);
                break;
            case "Garage":
                SetCurrentPosition(83.85f, 1.772f, -114.34f);
                break;
            case "Hill":
                SetCurrentPosition(68.33f, 1.772f, -145.27f);
                break;
            case "Free":
                SetCurrentPosition(-16.21f, 1.772f, -123.56f);
                SetCurrentAngle(0, 0, 0);
                break;
            case "StopLine":
                IsPlayesCollision();
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Garage":
                SetCurrentPosition(102.42f, 1.772f, -113.76f);
                SetCurrentAngle(0, -90, 0);
                break;
            case "Parking":
                SetCurrentPosition(79.91f, 1.772f, -113.43f);
                break;
        }
    }

    private void IsPlayesCollision()
    {
        transform.position = CurrentPos;
        transform.eulerAngles = CurrentAngle;

        RearWheelDrive.isBraking = true;
        RearWheelDrive.currentTorque = 0;  

        var a = gameObject.GetComponent<Rigidbody>();
        
        a.velocity = Vector3.zero;
        a.angularVelocity  = Vector3.zero;
    }

    private void SetCurrentPosition(float a, float b, float c)
    {
        CurrentPos = new Vector3(a, b, c);
    }

    private void SetCurrentAngle(float a, float b, float c)
    {
        CurrentAngle = new Vector3(a, b, c);
    }
}
