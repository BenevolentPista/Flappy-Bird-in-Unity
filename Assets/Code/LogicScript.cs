using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource audioSource;
    public string sceneName = "";
    public string keyValue;
    private bool isGameOver = false;

    public void InitializeHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = $"High Score: {highScore}";
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (!isGameOver)
        {
            audioSource.Play();
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void RestartGame()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log($"Scene name = {sceneName}");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = $"High Score: {playerScore}";
        }

        gameOverScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
