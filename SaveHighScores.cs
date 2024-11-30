using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighScores : MonoBehaviour
{
    [SerializeField] const int NUM_HIGH_SCORES = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName";
    [SerializeField] const string SCORE_KEY = "HighScore";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] int playerLives;  // Variable to store the remaining lives

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetPlayerName(); // Get player name
        playerScore = PersistentData.Instance.getScore(); // Get current score
        playerLives = PersistentData.Instance.GetLives(); // Get remaining lives

        // Calculate final score based on player score and remaining lives
        int finalScore = CalculateFinalScore(playerScore, playerLives);

        SaveScore(finalScore);
        DisplayHighScores();
    }

    private int CalculateFinalScore(int score, int lives)
    {
        return score + (lives * 2);  
    }

    private void SaveScore(int finalScore)
    {
        int tempFinalScore = finalScore;  // Save the original final score
        string tempName = playerName;     // Save the original player name

        // Loop through all the high score positions
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                // If the new score is higher, insert it into the current position
                if (tempFinalScore > currentScore)
                {
                    // Store the old score and name in temporary variables
                    int tempScore = currentScore;
                    string tempPlayerName = PlayerPrefs.GetString(currentNameKey);

                    // Set the new high score
                    PlayerPrefs.SetString(currentNameKey, tempName);
                    PlayerPrefs.SetInt(currentScoreKey, tempFinalScore);

                    // Now swap the old score and name into the next position
                    tempFinalScore = tempScore;
                    tempName = tempPlayerName;
                }
            }
            else
            {
                // If there's no high score at this position, set the new score
                PlayerPrefs.SetString(currentNameKey, tempName);
                PlayerPrefs.SetInt(currentScoreKey, tempFinalScore);
                return;  // Exit the loop after saving the score
            }
        }
    }

    public void DisplayHighScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string name = PlayerPrefs.GetString(NAME_KEY + i);
            int score = PlayerPrefs.GetInt(SCORE_KEY + i);
            nameTexts[i].text = name;
            scoreTexts[i].text = score.ToString();
        }
        string currentPlayerName = PersistentData.Instance.GetPlayerName();
        int currentFinalScore = CalculateFinalScore(playerScore, playerLives);
        
    }
}
