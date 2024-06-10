using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject gameCredits;
    public GameObject gameMenu;
    public static GameController instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);           
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    
    public void ShowGameWin()
    {
        gameWin.SetActive(true);           
    }

    public void ShowMenu(string menu)
    {
        gameMenu.SetActive(true);           
    }
     public void ShowCredits(string creditos)
    {
        gameCredits.SetActive(true);           
    }
}

