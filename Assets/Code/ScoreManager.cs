using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int currentScore;

    private const string SCORE_KEY = "HighScore";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentScore = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{currentScore}";

        if (highScoreText != null)
            highScoreText.text = $"High Score: {GetHighScore()}";
    }

    public void SaveScore()
    {
        int best = PlayerPrefs.GetInt(SCORE_KEY, 0);
        if (currentScore > best)
        {
            PlayerPrefs.SetInt(SCORE_KEY, currentScore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
    }



    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY, 0);
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}
