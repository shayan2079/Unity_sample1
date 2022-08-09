using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] GameObject endMenu;
    [SerializeField] TextMeshProUGUI menuScoreBoard;

    int score;

    void Start()
    {
        score = 0;
        DisplayScore();
    }

    
    public void AddScore()
    {
        score++;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreBoard.text = "SCORE: " + score;
    }

    public void DisplayEndGameMenu()
    {
        scoreBoard.gameObject.SetActive(false);
        endMenu.SetActive(true);
        menuScoreBoard.text = "SCORE: " + score;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
