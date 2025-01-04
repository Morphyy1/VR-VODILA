using UnityEngine;


public class Trigger : MonoBehaviour
{
    public Vector3 CurrentPos = new Vector3(-1.38f, 1.772f, -139.57f);
    private Vector3 CurrentAngle = new Vector3(0, 90, 0);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Conus")
        {
            transform.position = CurrentPos;
            transform.eulerAngles = CurrentAngle;
            RearWheelDrive.isBraking = true;     
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Snake":
                CurrentPos = new Vector3(69.02f, 1.772f, -123.97f);
                break;  
            case "Rotation 1":
                CurrentPos = new Vector3(121.41f, 1.772f, -150.29f);
                CurrentAngle = new Vector3(0, 180, 0);
                break;
            case "Rotation 2":
                CurrentPos = new Vector3(83.85f, 1.772f, -152.02f);
                CurrentAngle = new Vector3(0, 0, 0);
                break;
            case "Garage":
                CurrentPos = new Vector3(83.85f, 1.772f, -114.34f);
                break;
            case "Hill":
                CurrentPos = new Vector3(68.33f, 1.772f, -145.27f);
                break;
            case "Free":
                CurrentPos = new Vector3(-16.21f, 1.772f, -123.56f);
                CurrentAngle = new Vector3(0, 0, 0);
                break;
            case "StopLine":
                transform.position = CurrentPos;
                transform.eulerAngles = CurrentAngle;
                RearWheelDrive.isBraking = true;  
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Garage":
                CurrentPos = new Vector3(102.42f, 1.772f, -113.76f);
                CurrentAngle = new Vector3(0, -90, 0);
                break;
            case "Parking":
                CurrentPos = new Vector3(79.91f, 1.772f, -113.43f);
                break;
        }
    }
}
