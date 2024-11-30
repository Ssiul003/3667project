using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI for the legacy Text component
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance;
    private int score;
    public Text scoreText; 
    private int level;
    private int initialScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    
    

private void Start()
{
    level = SceneManager.GetActiveScene().buildIndex;
    
    if (level == 0) 
    {
        ResetScore();
    }
    else
    {
        score = PersistentData.Instance.getScore(); 
    }

    initialScore = score;  

    UpdateScoreText(); 
}



    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); 
        PersistentData.Instance.setScore(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText(); 
        PersistentData.Instance.setScore(score);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void ResetScoreToInitial()
{
    score = initialScore; 
    UpdateScoreText(); 
    PersistentData.Instance.setScore(score); 
}

}
