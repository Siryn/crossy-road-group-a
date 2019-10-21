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
    public int score = 0;
    public Text highScoreText;
    public Text coinsText;
    public int coins = 0;

    private void Start()
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
        storePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        print("PRINT BUTTON!!!!!!");
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
        print("mainmenue");
    }

    public void OnClickPlayAgainButton()
    {
        SceneManager.LoadScene("andrewScene");
        startPanel.SetActive(false);
    }

    //for when you die
    public void OnDeathEvent()
    {
        endPanel.SetActive(true);
    }
}
