using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float minYAngle = 10f;
    public float maxYAngle = 20f;
    public float smoothSpeed = 0.125f;
    public float zoomSpeed = 2f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float panSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(1))
        {
            // Âðàùåíèå âîêðóã òåêóùåé ïîçèöèè êàìåðû
            Vector3 pivot = transform.position;
            transform.RotateAround(pivot, Vector3.up, -horizontalInput * rotateSpeed * Time.deltaTime);
            transform.RotateAround(pivot, transform.right, -verticalInput * rotateSpeed * Time.deltaTime);

            float currentXAngle = transform.eulerAngles.x;
            currentXAngle = Mathf.Clamp(currentXAngle, minYAngle, maxYAngle);
            transform.eulerAngles = new Vector3(currentXAngle, transform.eulerAngles.y, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            // Ïåðåìåùåíèå êàìåðû ïðè íàæàòèè ËÊÌ
            Vector3 rightDirection = transform.right;
            rightDirection.y = 0;

            Vector3 forwardDirection = transform.forward;
            forwardDirection.y = 0;

            transform.position -= rightDirection * horizontalInput * panSpeed * Time.deltaTime;
            transform.position -= forwardDirection * verticalInput * panSpeed * Time.deltaTime;

            // Îãðàíè÷èâàåì ïåðåìåùåíèå â ïðåäåëàõ îãðàíè÷åííîé çîíû
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            transform.position = newPosition;
        }

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, transform.position, ref velocity, smoothSpeed);
        transform.position = smoothPosition;

        float zoomAmount = scrollInput * zoomSpeed;
        float newZoom = Mathf.Clamp(transform.position.y - zoomAmount, minZoom, maxZoom);
        transform.position = new Vector3(transform.position.x, newZoom, transform.position.z);
    }

    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
}
