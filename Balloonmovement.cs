using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 10.0f; // Speed of the balloon movement
    private Vector3 direction = Vector3.right; // Initial movement direction

    private float screenWidth;

    void Start()
    {
        // Get screen width in world coordinates
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Move the balloon
        transform.position += direction * speed * Time.deltaTime;

        // Check if the balloon hits the edges of the screen
        if (transform.position.x >= screenWidth || transform.position.x <= -screenWidth)
        {
            // Reverse direction
            direction *= -1;
        }
    }
}
