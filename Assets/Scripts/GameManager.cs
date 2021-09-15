using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>Class <c>GameManager</c> models the game manager object</summary>
public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas, scoreCanvas;
    public Player player;
    private int score;
    [SerializeField]
    private Sprite[] scoreSprites;
    private Image score0, score1;
    private Image gameOverScore0, gameOverScore1;
    private Image gameOverBestScore0, gameOverBestScore1;

    // Start is called before the first frame update
    void Start()
    {
        scoreCanvas = GameObject.Find(Utils.CANVAS_SCORE);
        // Score Images
        score0 = GameObject.Find(Utils.IMAGE_SCORE_0).GetComponent<Image>();
        score1 = GameObject.Find(Utils.IMAGE_SCORE_1).GetComponent<Image>();
        gameOverScore0 = GameObject.Find(Utils.IMAGE_GAMEOVER_SCORE_0).GetComponent<Image>();
        gameOverScore1 = GameObject.Find(Utils.IMAGE_GAMEOVER_SCORE_1).GetComponent<Image>();
        gameOverBestScore0 = GameObject.Find(Utils.IMAGE_GAMEOVER_BEST_SCORE_0).GetComponent<Image>();
        gameOverBestScore1 = GameObject.Find(Utils.IMAGE_GAMEOVER_BEST_SCORE_1).GetComponent<Image>();
        //
        gameOverCanvas = GameObject.Find(Utils.CANVAS_GAMEOVER);
        gameOverCanvas.SetActive(false);
        score = 0;
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

    /// <summary>Start a new game by starting timescale and setting score to 0</summary>
    public void StartGame()
    {
        Time.timeScale = 1;
        score = 0;
        score1.sprite = scoreSprites[0];
        score0.sprite = scoreSprites[0];
    }

    /// <summary>Restart a new game by loading the main scene and calling the <c>StartGame</c> function</summary>
    /// <see cref="StartGame"/>
    public void RestartGame()
    {
        SceneManager.LoadScene(Utils.SCENE_GAMEPLAY);
        StartGame();
    }

    /// <summary> Display GameOver canvas, stop timescale, display scores and save score if highscore </summary>
    /// <see cref="DisplayHighScore"/>
    /// <see cref="DisplayScore"/>
    /// <see cref="setScoreSprite"/>
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        Time.timeScale = 0;
        if (score > PlayerPrefs.GetInt(Utils.PLAYER_PREFS_HIGHSCORE)) {
            PlayerPrefs.SetInt(Utils.PLAYER_PREFS_HIGHSCORE, score);
        }
        DisplayHighScore();
        DisplayScore();
    }

    /// <summary> Display highscore </summary>
    /// <see cref="GameOver"/>
    /// <see cref="DisplayScore"/>
    /// <see cref="setScoreSprite"/>
    private void DisplayHighScore() {
        setScoreSprite(gameOverBestScore0, gameOverBestScore1, PlayerPrefs.GetInt(Utils.PLAYER_PREFS_HIGHSCORE));
    }

    /// <summary> Display score </summary>
    /// <see cref="GameOver"/>
    /// <see cref="DisplayHighScore"/>
    /// <see cref="setScoreSprite"/>
    private void DisplayScore() {
        setScoreSprite(gameOverScore0, gameOverScore1, score);
    }

    public void PlayerDiedListener()
    {
        GameOver();
    }

    public void ScoreListener()
    {
        score += 1;
        setScoreSprite(score0, score1, score);
    }

    /// <summary>Set score sprites</summary>
    /// <param name="scoreImg0">Score first digit</param>
    /// <param name="scoreImg1">Score second digit</param>
    /// <param name="score">Score value that you want to display</param>
    /// <see cref="GameOver"/>
    /// <see cref="DisplayHighScore"/>
    /// <see cref="DisplayScore"/>
    private void setScoreSprite(Image scoreImg0, Image scoreImg1, int score) {
        if (score > 9)
        {
            scoreImg0.sprite = scoreSprites[score.ToString()[0] - '0']; // see https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
            scoreImg1.sprite = scoreSprites[score.ToString()[1] - '0']; // see https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
        }
        else
        {
            scoreImg1.sprite = scoreSprites[score];
        }
    }
}
