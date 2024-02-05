using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private AsteroidSpawner asterioidSpawner;
    [SerializeField] private Score score;
    [SerializeField] private TMP_Text yourScoreText;
    public void EndGame()
    {
        gameOverCanvas.SetActive(true);
        asterioidSpawner.enabled = false;
        score.ScoreEndGame();
        float endGameScore = score.ScoreEndGame();
        yourScoreText.text = $"Your Score: " + endGameScore;
    }
    public void GoToHomeScreen()
    {
        SceneManager.LoadScene(1);

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);   

    }
    public void Continous()
    {

    }



}
