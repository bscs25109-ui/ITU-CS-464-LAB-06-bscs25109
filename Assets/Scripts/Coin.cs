using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int worth = 1;

    void Update() => transform.Rotate(0f, 90f * Time.deltaTime, 0f);

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin touched by: " + other.name);  // ← add this

        if (!other.CompareTag("Player")) return;
        GameManager.Instance.AddScore(worth);
        Destroy(gameObject);
    }
}