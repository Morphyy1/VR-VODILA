using UnityEngine;

public class SteerRotate : MonoBehaviour
{
    public float rotationSpeed = 300f; // Скорость вращения руля
    public float returnSpeed = 10f; // Скорость возврата руля в исходное положение
    public float maxRotationAngle = 80f; // Максимальный угол вращения руля
    private Quaternion initialRotation; // Исходное вращение руля
    private float currentAngle = 0f; // Текущий угол вращения

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        currentAngle = Mathf.Clamp(currentAngle + horizontalMove * rotationSpeed * Time.deltaTime, -maxRotationAngle, maxRotationAngle);
        transform.localRotation = initialRotation * Quaternion.Euler(0, 0, currentAngle);

        if (horizontalMove == 0)
        {
            currentAngle = Mathf.LerpAngle(currentAngle, 0, returnSpeed * Time.deltaTime);
            transform.localRotation = initialRotation * Quaternion.Euler(0, 0, currentAngle);
        }
    }
}