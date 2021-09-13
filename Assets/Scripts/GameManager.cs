using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas, scoreCanvas;
    public Player player;
    private int score;
    [SerializeField]
    private Sprite[] scoreSprites;
    private Image score0, score1;

    // Start is called before the first frame update
    void Start()
    {
        scoreCanvas = GameObject.Find("ScoreCanvas");
        score0 = GameObject.Find("Score_0").GetComponent<Image>();
        score1 = GameObject.Find("Score_1").GetComponent<Image>();
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.SetActive(false);
        score = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        score = 0;
        score1.sprite = scoreSprites[0];
        score0.sprite = scoreSprites[0];
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
        if (score > PlayerPrefs.GetInt("highScore")) {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void PlayerDiedListener()
    {
        GameOver();
    }

    public void ScoreListener()
    {
        score += 1;
        if (score >= 10)
        {
            score0.sprite = scoreSprites[score.ToString()[0] - '0']; // see https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
            score1.sprite = scoreSprites[score.ToString()[1] - '0']; // see https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
        }
        else
        {
            score1.sprite = scoreSprites[score];
        }
    }

    private void OnEnable()
    {
        Player.playerDiedInfo += PlayerDiedListener;
        Player.score += ScoreListener;
    }

    private void OnDisable()
    {
        Player.playerDiedInfo -= PlayerDiedListener;
        Player.score -= ScoreListener;
    }
}
