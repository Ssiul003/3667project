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
                audioSource.volume = AudioListener.volume; // Align with global volume
                audioSource.Play();
                
            }

            // Deactivate the balloon instead of respawning it
            collision.gameObject.SetActive(false);

            // Add 1 point to the score
            ScoreCount.instance.AddScore(1);

            // Notify BalloonManager that a balloon has been "popped"
            BalloonManager.instance.BalloonPopped();

            Destroy(gameObject, audioSource.clip.length);
        }

        if (collision.CompareTag("Bird"))
{
    // Decrease lives when the pin hits a bird
    int currentLives = PersistentData.Instance.GetLives();
    currentLives--;  // Decrement lives
    PersistentData.Instance.SetLives(currentLives);

    // Update the lives display
    FindObjectOfType<LivesDisplay>().UpdateLivesDisplay();

    if (currentLives <= 0)
    {
        GoToMenu();
    }
    else
    {
        // Reset the score to the initial value when losing a life
        ScoreCount.instance.ResetScoreToInitial();

        // Optionally, you can reload the level to reset the game state
        RestartLevel();
    }
}

}



    private void RestartLevel()
    {
    // Optionally reset score here as well if needed before reloading
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    private void GoToMenu()
    {
    // Reset the game state (including score and lives) only when going to the main menu
    PersistentData.Instance.ResetGame();
    SceneManager.LoadScene(0); // Load the main menu scene (index 0)
    }


}
