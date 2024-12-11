using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float CarSpeedTest = 800f;
    private Rigidbody _carBody;

    private void Awake()
    {
        _carBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var horizontalMove = Input.GetAxis("Horizontal");
        var verticalMove = Input.GetAxis("Vertical");

        _carBody.AddForce(new Vector3(horizontalMove, _carBody.velocity.y, verticalMove) * CarSpeedTest * Time.fixedDeltaTime);
    }
}
