using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerTD : MonoBehaviour
{
    public static UIManagerTD Instance;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameViewPanel;
    [SerializeField] private GameObject gameOverPanel;
    
    [Header("Texts")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    [Header("Player Info")] 
    [SerializeField] private Image playerHealthImage;
    
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(float newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }

    public void UpdateHealthBar(float fillAmount)
    {
        playerHealthImage.fillAmount = fillAmount;
    }

    public void UpdateHighscore(float highscore)
    {
        highscoreText.text = $"Highscore: {highscore}";
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameViewPanel.SetActive(false);
    }
    
    public void ShowGameView()
    {
        mainMenuPanel.SetActive(false);
        gameViewPanel.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameViewPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
