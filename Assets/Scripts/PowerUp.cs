using UnityEngine;

public enum PowerUpType { Speed, Shield }

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpType type = PowerUpType.Speed;
    [SerializeField] float multiplier = 1.6f;   // Speed only: how much faster
    [SerializeField] float duration = 5f;     // Speed only: how many seconds
    void OnTriggerEnter(Collider other)
    {
        // Only react to the Player
        if (!other.CompareTag("Player")) return;

        if (type == PowerUpType.Speed)
            other.GetComponent<PlayerController>().BoostSpeed(multiplier, duration);
        else
            other.GetComponent<Health>().shielded = true;

        Destroy(gameObject);   // consume the pickup
    }
}