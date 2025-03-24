using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1.0f;
    public GameObject prefab;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject newPrefab = Instantiate(prefab, transform.position, transform.rotation);
    }
}
