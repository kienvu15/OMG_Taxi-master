using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject slider;

    public GameObject bestScore;
    public GameObject startPanel;

    public GameObject endPanel;
    void Start()
    {
        scoreText.SetActive(false);
        slider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StratGame()
    {
        startPanel.SetActive(false);
        bestScore.SetActive(false);

        scoreText.SetActive(true);
        slider.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
