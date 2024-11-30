using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 10.0f; // Speed of the balloon movement
    private Vector3 direction = Vector3.left; // Initial movement direction

    private float screenWidth;

    void Start()
    {
        // Get screen width in world coordinates
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Move the bird
        transform.position += direction * speed * Time.deltaTime;

        // Check if the bird hits the edges of the screen
        if (transform.position.x >= screenWidth || transform.position.x <= -screenWidth)
        {
            // Reverse direction
            direction *= -1;

            // Flip the bird's image
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Invert the X-axis
            transform.localScale = scale;
        }
    }
}
