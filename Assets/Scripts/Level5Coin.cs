using UnityEngine;

public class Level5Coin : MonoBehaviour
{
    void Update() => transform.Rotate(0f, 90f * Time.deltaTime, 0f);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Level5Manager manager = FindObjectOfType<Level5Manager>();
            if (manager != null) manager.AddScore(1);
            Destroy(gameObject);
        }
    }
}