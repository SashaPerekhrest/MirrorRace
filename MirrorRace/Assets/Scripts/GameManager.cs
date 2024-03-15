using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameActive;
    public bool gameIsPaused;
    public int score;

    public GameObject loseMenu;
    public Text scoreT;
    public Text highScore;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameScore;

    void Awake()
    {
        GameActive = true;
        gameIsPaused = false;
        score = 0;
        if (!PlayerPrefs.HasKey("High"))
        {
            PlayerPrefs.SetInt("High", score);
        }
    }

    private void FixedUpdate()
    {
        if (!GameActive) 
        {
            loseMenu.SetActive(true);
            pauseButton.SetActive(false);
            gameScore.SetActive(false);
            scoreT.text ="Score: " + score.ToString();
            var highS = PlayerPrefs.GetInt("High");
            if (highS < score) 
            {
                highS = score;
                PlayerPrefs.SetInt("High", highS);
            }
            highScore.text = "High score: " + highS.ToString();
        }
    }

    public void PauseClick()
    { 
        gameIsPaused = !gameIsPaused;
        pauseMenu.SetActive(gameIsPaused);
        PauseGame();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    private void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
