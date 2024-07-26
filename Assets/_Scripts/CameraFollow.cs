using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // How smoothly the camera moves
    public Vector3 offset; // Offset from the player's position

    void FixedUpdate()
    {
        // Define the target position
        Vector3 desiredPosition = player.position + offset;
        // Smoothly interpolate between the camera's current position and the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
