using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject creditsPanel;

    private void Start()
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
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
    }
}
