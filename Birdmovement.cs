using UnityEngine;

public class Birdmovement : MonoBehaviour
{
    public float speed = 5f; 
    public float leftLimit = -8f;
    public float rightLimit = 8f; 
    private bool movingLeft = true; 

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime * (movingLeft ? 1 : -1));

        
        if (transform.position.x <= leftLimit || transform.position.x >= rightLimit)
        {
            Flip(); 
        }
    }

    private void Flip()
    {
        movingLeft = !movingLeft; 
        Vector3 theScale = transform.localScale; 
        theScale.x *= -1; 
        transform.localScale = theScale; 
    }
}
