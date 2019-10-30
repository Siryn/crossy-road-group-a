using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject creditsPanel;
    public GameObject endPanel;
    public GameObject player;

    public Text scoreText;
    //public int score = 0;
    public Text highScoreText;
    public Text coinsText;
    public int coins = 0;
    public Text deathText;

    public HighScoreManager highScoreManager;

    private void Start()
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = GlobalVariables.playerXPosition.ToString();
        if (GlobalVariables.playerXPosition < highScoreManager.highScores[0])
        {
            highScoreText.text = highScoreManager.highScores[0].ToString();
        }
        else
        {
            highScoreText.text = GlobalVariables.playerXPosition.ToString();
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickCreditsButton()
    {
        creditsPanel.SetActive(true);
    }

    public void OnClickBackButton()
    {
        creditsPanel.SetActive(false);
    }

    public void OnClickPlayButton()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    public void OnClickPlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetGlobalVariables();
        highScoreManager.ReadHighScores();
    }

    //for when you die
    public void OnDeathEvent()
    {
        endPanel.SetActive(true);
        highScoreManager.SaveHighScores(GlobalVariables.playerXPosition);

        string newString = "";
        foreach (int score in highScoreManager.highScores)
        {
            newString = newString + score + "\n";
        }

        deathText.text = "High Scores: \n" + newString;

    }
    public void ResetGlobalVariables()
    {
        GlobalVariables.playerXPosition = 0;
        GlobalVariables.currentMaxRow = 0;
        GlobalVariables.tileCells = 15;
        GlobalVariables.tileRows = 15;
        GlobalVariables.safeRows = 11;
        GlobalVariables.generationThreshold = 15;
        GlobalVariables.rowDensity = 0.75f;
        GlobalVariables.generationDensity = 0.75f;
    }
}
