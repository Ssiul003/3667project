using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonManager : MonoBehaviour
{
    public static BalloonManager instance;
    private int balloonCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Count all balloons in the scene initially
        balloonCount = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }

    // Called by PinMovement when a balloon is "popped"
    public void BalloonPopped()
    {
        balloonCount--;
        // Check if all balloons are popped
        if (balloonCount <= 0)
        {

            LoadNextScene();
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
    
}

}
