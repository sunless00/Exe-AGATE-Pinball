using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Collider bola;

    public Button playButton;
    public Button creditButton;
    public Button exitButton;
    public Button mainMenu;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitButton);
        creditButton.onClick.AddListener(CreditButton);
        mainMenu.onClick.AddListener(MenuButton);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball");
    }

    private void CreditButton()
    {
        SceneManager.LoadScene("CreditMenu");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            GameOver();
        }
    }
}
