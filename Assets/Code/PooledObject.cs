using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public float bonusTime = 3f;

    public AudioSource source;
    public AudioClip clip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(clip);
            TimeSlider slider = FindFirstObjectByType<TimeSlider>();
            if (slider != null)
            {
                slider.AddTime(bonusTime);
            }

            ObjectPool.Instance.ReturnToPool(gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }
}
