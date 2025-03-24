using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHeightSpawner : Spawner
{
    public float minHeight = -1.0f;
    public float maxHeight = 1.0f;

    private void Spawn()
    {
        GameObject newPrefab = Instantiate(prefab, transform.position + Vector3.up * Random.Range(minHeight, maxHeight), transform.rotation);
    }
}
