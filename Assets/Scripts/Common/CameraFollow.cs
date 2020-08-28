using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        var desiredPosition = player.position + new Vector3(0f, 0f, -10f);
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}

