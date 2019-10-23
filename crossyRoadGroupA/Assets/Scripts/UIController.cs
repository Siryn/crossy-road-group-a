using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject creditsPanel;
    public GameObject storePanel;
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
        storePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = GlobalVariables.playerXPosition.ToString();
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

    public void OnClickStoreButton()
    {
        storePanel.SetActive(true);
    }

    public void OnClickStoreBackButton()
    {
        storePanel.SetActive(false);
    }

    public void OnClickMainMenuButton()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        print("mainmenu");
    }

    public void OnClickPlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startPanel.SetActive(false);
    }

    //for when you die
    public void OnDeathEvent()
    {
        endPanel.SetActive(true);
        highScoreManager.SaveHighScores(GlobalVariables.playerXPosition);
        //deathText.text = "High Scores: \n Test";
        string newString = "";
        foreach (int score in highScoreManager.highScores)
        {
            //print(score);
            newString = newString + score + "\n";
        }

        deathText.text = "High Scores: \n" + newString;

        /*for (int i = 0; i < highScoreManager.highScores.Length; i++)
        {
            deathText.text += "" + highScoreManager.highScores[i].ToString() + "\n";
        }*/
    }
}
