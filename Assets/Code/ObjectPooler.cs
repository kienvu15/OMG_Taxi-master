using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [Header("Prefab cần spawn")]
    public GameObject prefab;

    [Header("Số lượng object trong pool")]
    public int poolSize = 10;

    [Header("Phạm vi spawn (x, y, z)")]
    public Vector3 center;
    public Vector3 size;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Tạo sẵn pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            obj.SetActive(true);
            pool.Add(obj);
        }
    }

    public Vector3 GetRandomPosition()
    {
        return center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2)
        );
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        // Spawn lại ở vị trí mới
        obj.transform.position = GetRandomPosition();
        obj.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
}
