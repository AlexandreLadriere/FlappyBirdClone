using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        StartGame();
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerDiedListener()
    {
        GameOver();
    }

    private void OnEnable()
    {
        Player.playerDiedInfo += PlayerDiedListener;
    }

    private void OnDisable()
    {
        Player.playerDiedInfo -= PlayerDiedListener;
    }
}
