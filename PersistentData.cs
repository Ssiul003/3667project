using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    private int lives;
    private int score;
    private string playerName;
    public TextMeshProUGUI nameText; // Reference to the UI Text component for displaying player name.
    public InputField nameInputField; // Reference to the InputField for player name input.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        // Automatically find nameText if not assigned
        if (nameText == null)
        {
            nameText = GameObject.Find("PlayerNameText")?.GetComponent<TextMeshProUGUI>();
        }

        // Automatically find nameInputField if not assigned
        if (nameInputField == null)
        {
            nameInputField = GameObject.Find("NameInputField")?.GetComponent<InputField>();
        }

        // Set up the InputField to listen for the end edit event
        if (nameInputField != null)
        {
            nameInputField.onEndEdit.AddListener(OnNameInputEndEdit);
        }

        // Initialize lives and playerName
        if (lives == 0)
        {
            lives = 3; // Default number of lives at game start
        }

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";  // Default name if no player name is set
        }

        UpdateNameDisplay(); // Update the name display when the scene starts

        // Subscribe to scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int level = scene.buildIndex;

        // If we're loading the home screen (or the scene where you want the score reset)
        if (level == 0) // Assuming the home screen has a build index of 0
        {
            ResetScore(); // Reset the score when returning to home screen
        }
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
        UpdateNameDisplay(); // Update UI whenever name is set
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int value)
    {
        lives = value;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int value)
    {
        score = value;
    }

    // Reset game state (lives and score)
    public void ResetGame()
    {
        lives = 3;
        score = 0;
    }

    // Reset the score to 0
    public void ResetScore()
    {
        score = 0;
        lives=3;
        UpdateNameDisplay();
    }

    // Update the name text in UI
    private void UpdateNameDisplay()
    {
        if (nameText != null)
        {
            nameText.text = playerName;
        }
    }

    // When name input ends, set the player name
    public void OnNameInputEndEdit(string inputName)
    {
        SetPlayerName(inputName); // Save the entered name
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from sceneLoaded event when destroyed
    }
}
