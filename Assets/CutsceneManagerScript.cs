using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class CutsceneManagerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button skipButton;

    void Start()
    {
        // Ensure the skip button is initially invisible and non-functional
        skipButton.gameObject.SetActive(false);
        
        // Start the coroutine to enable the button after 3 seconds
        StartCoroutine(EnableSkipButtonAfterDelay(5f));
        
        // Play the video
        videoPlayer.Play();
        
        // Add an event listener to detect when the video finishes
        videoPlayer.loopPointReached += EndReached;
    }

    IEnumerator EnableSkipButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        skipButton.gameObject.SetActive(true);
        skipButton.onClick.AddListener(SkipVideo);
    }

    void SkipVideo()
    {
        // Load the CharacterSelectScene when the skip button is pressed
        SceneManager.LoadScene("CharacterSelectScene");
    }

    void EndReached(VideoPlayer vp)
    {
        // Load the CharacterSelectScene when the video finishes
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
