
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PinMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private Vector2 movementDirection; 
    private bool isMoving = false;
    private bool isSceneChanging = false;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(movementDirection * speed * Time.deltaTime);
        }
    }

    public void StartMoving(Vector2 direction)
    {
        movementDirection = direction; 
        isMoving = true; 
    }
private void OnTriggerEnter2D(Collider2D collision)
{
    
    if (collision.CompareTag("Balloon") && !isSceneChanging)
    {
        isSceneChanging = true;
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Playing sound effect");
        }
        BalloonMovement balloonMovement = collision.GetComponent<BalloonMovement>();
        if (balloonMovement != null)
        {
            balloonMovement.Respawn(); 
        }

        ScoreCount.instance.AddScore(1);
        Invoke("LoadNextScene", audioSource.clip.length);

       
        Destroy(gameObject, audioSource.clip.length);
    }
    if (collision.CompareTag("Bird"))
    {
        Debug.Log("Hit a bird! Restarting level.");
        RestartLevel(); 
    }

}

private void LoadNextScene()
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    
    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextSceneIndex); 
    }
    else
    {
        Debug.Log("No more scenes to load."); 
    }
}
private void RestartLevel()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
}
}


