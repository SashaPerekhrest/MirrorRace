using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text highT;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("High"))
        {
            PlayerPrefs.SetInt("High", 0);
        }
        highT.text = "high score: " + PlayerPrefs.GetInt("High");
    }
    public void StartGame()
    {     
        SceneManager.LoadScene("SampleScene");
    }
}
