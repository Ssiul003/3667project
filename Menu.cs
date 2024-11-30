using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Function to load the game scene
    public void Play()
    {
        SceneManager.LoadScene("Level1"); 
    }

    // Function to load the instructions scene
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions"); 
    }

    // Function to load the settings scene
    public void Settings()
    {
        SceneManager.LoadScene("Settings"); 
    }
    
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
