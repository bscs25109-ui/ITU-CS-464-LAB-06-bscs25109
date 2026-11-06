//using System.Collections;
//using UnityEngine;

//public class CoinSpawner : MonoBehaviour
//{
//    [SerializeField] GameObject coinPrefab;
//    [SerializeField] int count = 10;    // total coins to spawn
//    [SerializeField] float spawnRange = 8f;    // random X and Z range
//    [SerializeField] float spawnHeight = 0.6f;  // just above the floor
//    [SerializeField] float spawnInterval = 2f;   // seconds between each coin

//    IEnumerator Start()
//    {
//        for (int i = 0; i < count; i++)
//        {
//            Vector3 pos = new Vector3(
//                Random.Range(-spawnRange, spawnRange),
//                spawnHeight,
//                Random.Range(-spawnRange, spawnRange)
//            );
//            Instantiate(coinPrefab, pos, Quaternion.identity);
//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }
//}
using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int count = 10;
    [SerializeField] float spawnRange = 4f;
    [SerializeField] float spawnHeight = 0.6f;
    [SerializeField] float spawnInterval = 1f;

    [Header("Collision Check Settings")]
    [Tooltip("How wide the coin is. Prevents spawning inside walls.")]
    [SerializeField] float checkRadius = 0.5f;
    [Tooltip("How many times it will try to find an empty spot before giving up.")]
    [SerializeField] int maxAttempts = 30;

    IEnumerator Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = Vector3.zero;
            bool foundEmptySpot = false;
            int attempts = 0;

            // Keep trying to find an empty spot
            while (!foundEmptySpot && attempts < maxAttempts)
            {
                // Pick a random position
                spawnPos = new Vector3(
                    transform.position.x + Random.Range(-spawnRange, spawnRange),
                    spawnHeight,
                    transform.position.z + Random.Range(-spawnRange, spawnRange)
                );

                // Check if there is ANY collider at this position
                // We use "!" because CheckSphere returns true if it hits something
                if (!Physics.CheckSphere(spawnPos, checkRadius))
                {
                    foundEmptySpot = true;
                }

                attempts++;
            }

            // If we found an empty spot, spawn the coin!
            if (foundEmptySpot)
            {
                Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Could not find an empty spot for a coin. Area might be too crowded!");
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Draws a yellow box in the Scene view so you can see the spawn area
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = new Vector3(transform.position.x, spawnHeight, transform.position.z);
        Gizmos.DrawWireCube(center, new Vector3(spawnRange * 2, 0.1f, spawnRange * 2));
    }
}