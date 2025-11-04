using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour
{
    public float bonusTime = 3f;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (source != null && clip != null)
            {
                source.PlayOneShot(clip);
                StartCoroutine(ReturnAfterSound());
            }
            else
            {
                ObjectPool.Instance.ReturnToPool(gameObject);
            }

            TimeSlider slider = FindFirstObjectByType<TimeSlider>();
            if (slider != null)
                slider.AddTime(bonusTime);

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
                ScoreManager.Instance.SaveScore();
            }

        }
    }

    private IEnumerator ReturnAfterSound()
    {
        yield return new WaitForSeconds(0.2f);
        ObjectPool.Instance.ReturnToPool(gameObject);
    }
}
