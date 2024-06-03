using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button startButton;
    public Button quitButton;

    private bool videoPaused = false;

    void Start()
    {
        // Ensure the buttons are initially invisible and non-functional
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        // Play the video
        videoPlayer.Play();
    }

    void Update()
    {
        // Check if the video time has reached 3 seconds and it hasn't been paused yet
        if (videoPlayer.time >= 2.8f && !videoPaused)
        {
            PauseVideo();
        }
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
        videoPaused = true;
        ShowButtons();
    }

    void ShowButtons()
    {
        // Enable the buttons after pausing the video
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        // Add event listeners for the buttons
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        // Hide buttons and resume video
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        // Resume the video
        videoPlayer.Play();

        // Add an event listener to load the next scene when the video finishes
        videoPlayer.loopPointReached += EndReached;
    }

    void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    void EndReached(VideoPlayer vp)
    {
        // Load the CutScene scene when the video finishes
        SceneManager.LoadScene("CutScene");
    }
}