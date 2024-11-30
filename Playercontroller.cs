using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public GameObject pinPrefab;
    public Transform pinSpawnPoint; 
    public UnityEvent OnLandEvent;
    
    void Update()
{
    
    if (Input.GetButtonDown("Fire1"))
    {
        Vector2 shootDirection = Vector2.up;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        

        ShootPin(shootDirection);
    }
}

void ShootPin(Vector2 direction)
{
    GameObject pin = Instantiate(pinPrefab, pinSpawnPoint.position, Quaternion.identity);
    
    PinMovement pinMovement = pin.GetComponent<PinMovement>();
    if (pinMovement != null)
    {
        pinMovement.StartMoving(direction); 
    }
}
   
}
