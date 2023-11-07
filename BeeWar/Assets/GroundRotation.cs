using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    public float rotateSpeed = 5f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float rotationAmount = -horizontalInput * rotateSpeed * Time.deltaTime;

            // Вращение Terrain вокруг оси Y
            transform.Rotate(Vector3.up, rotationAmount, Space.World);
        }
    }
}