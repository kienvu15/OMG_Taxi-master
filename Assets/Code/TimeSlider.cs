using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    public Slider timeSlider;       
    public float maxTime = 10f;     
    public float decreaseRate = 1f; 

    private float currentTime;

    public GameObject losePanel;
    public GameObject bestScore;

    void Start()
    {
        Time.timeScale = 1f;

        currentTime = maxTime;
        timeSlider.maxValue = maxTime;
        timeSlider.value = currentTime;
    }

    void Update()
    {
        currentTime -= decreaseRate * Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, maxTime);
        timeSlider.value = currentTime;

        if (currentTime <= 0)
        {
            ScoreManager.Instance.SaveScore();
            losePanel.SetActive(true);
            bestScore.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        currentTime = Mathf.Clamp(currentTime, 0, maxTime);
    }


}
