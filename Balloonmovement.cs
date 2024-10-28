using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 2.0f; 
    public float speedIncrement = 1.0f;
    private Vector2 direction = Vector2.right; 

    
    private Vector2 initialPosition;

    
    public float spawnXMin = -8.0f; 
    public float spawnXMax = 8.0f;  
    private void Start()
    {

        initialPosition = transform.position;

        
        float screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    private void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);

        
        CheckHorizontalBoundaries();
    }

    private void CheckHorizontalBoundaries()
    {
        Vector2 position = transform.position;

    
        if (position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x || 
            position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            direction.x = -direction.x; 
        }
    }

    // Method to respawn the balloon at a random position within the defined range
    public void Respawn()
    {
        
        float randomX = Random.Range(spawnXMin, spawnXMax);
        transform.position = new Vector2(randomX, transform.position.y);
        
        speed += speedIncrement; 
        

        gameObject.SetActive(true); 
    }
}
