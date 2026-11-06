using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int count = 10;    // total coins to spawn
    [SerializeField] float spawnRange = 8f;    // random X and Z range
    [SerializeField] float spawnHeight = 0.6f;  // just above the floor
    [SerializeField] float spawnInterval = 2f;   // seconds between each coin

    IEnumerator Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                spawnHeight,
                Random.Range(-spawnRange, spawnRange)
            );
            Instantiate(coinPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}