using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour
{
    public GameObject optionsPanel; //Store a reference to the Game Object OptionsPanel 
    public GameObject optionsTint; //Store a reference to the Game Object OptionsTint 
    public GameObject highscorePanel;
    public GameObject creditsPanel;
    public GameObject menuPanel; //Store a reference to the Game Object MenuPanel 
    public GameObject pausePanel; //Store a reference to the Game Object PausePanel 


    // === show functions ===

    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
        optionsTint.SetActive(true);
    }
    
    public void ShowHighscorePanel()
    {
        highscorePanel.SetActive(true);
        highscorePanel.SetActive(true);
    }
    
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        creditsPanel.SetActive(true);
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        optionsTint.SetActive(true);
    }


    // === hide functions ===

    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
        optionsTint.SetActive(false);
    }
    
    public void HideHighscorePanel()
    {
        highscorePanel.SetActive(false);
        highscorePanel.SetActive(false);
    }
    
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        optionsTint.SetActive(false);
    }
}