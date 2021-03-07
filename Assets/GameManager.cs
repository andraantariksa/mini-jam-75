using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverOverlay;

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverOverlay.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene("Scene/SampleScene", LoadSceneMode.Single);
    }

    public void GameOverIn(float seconds=2f)
    {
        Invoke(nameof(GameOver), seconds);
    }
}
