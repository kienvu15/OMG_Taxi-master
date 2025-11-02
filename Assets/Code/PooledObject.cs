using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public float bonusTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeSlider slider = FindFirstObjectByType<TimeSlider>();
            if (slider != null)
            {
                slider.AddTime(bonusTime);
            }

            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }
}
