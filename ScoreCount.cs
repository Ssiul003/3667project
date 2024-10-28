using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance;
    private int score; 

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

    public void AddScore(int points)
    {
        score += points; 
        Debug.Log("Current Score: " + score);
    }

    public int GetScore()
    {
        return score; 
    }

    public void ResetScore() 
    {
        score = 0; 
    }
}
