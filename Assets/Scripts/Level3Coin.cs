using UnityEngine;

public class Level3Coin : MonoBehaviour
{
    void Update()
    {
        // Spin the coin
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the Level 3 Manager and add 1 point
            Level3Manager manager = FindObjectOfType<Level3Manager>();
            if (manager != null)
            {
                manager.AddScore(1);
            }
            Destroy(gameObject);
        }
    }
}