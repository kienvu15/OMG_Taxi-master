using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    public Slider timeSlider;       // G?n Slider trong Inspector
    public float maxTime = 10f;     // Th?i gian t?i ?a
    public float decreaseRate = 1f; // Gi?m bao nhiêu m?i giây

    private float currentTime;

    void Start()
    {
        currentTime = maxTime;
        timeSlider.maxValue = maxTime;
        timeSlider.value = currentTime;
    }

    void Update()
    {
        // Gi?m d?n theo th?i gian
        currentTime -= decreaseRate * Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, maxTime);
        timeSlider.value = currentTime;

        // (Tùy ch?n) Làm gì ?ó khi h?t time
        if (currentTime <= 0)
        {
            Debug.Log("H?t th?i gian!");
        }
    }

    /// <summary>
    /// G?i hàm này khi player ?n item ?? c?ng thêm th?i gian
    /// </summary>
    public void AddTime(float amount)
    {
        currentTime += amount;
        currentTime = Mathf.Clamp(currentTime, 0, maxTime);
    }
}
