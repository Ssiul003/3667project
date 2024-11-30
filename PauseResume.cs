using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] playMode;

    public GameObject pauseButton;   // Reference to the Pause Button
    public GameObject resumeButton;  // Reference to the Resume Button

    void Start()
    {
        Time.timeScale = 1.0f;

        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");

        // Hide the pause button and show the resume button initially
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);

        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        foreach(GameObject g in pauseMode)
            g.SetActive(true);

        foreach(GameObject g in playMode)
            g.SetActive(false);

        // Show the resume button and hide the pause button
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(true);

        // Hide the resume button and show the pause button
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}
