using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Text livesText;

    void Start()
    {
        UpdateLivesDisplay(); // Initial update when the game starts
    }

    public void UpdateLivesDisplay()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + PersistentData.Instance.GetLives().ToString();
        }
    }
}
