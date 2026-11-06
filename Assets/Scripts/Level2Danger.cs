using UnityEngine;

public class Level2Danger : MonoBehaviour
{
    [SerializeField] float knockbackForce = 35f; // MASSIVE force to throw the player far away

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ApplyHit(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) ApplyHit(collision.gameObject);
    }

    void ApplyHit(GameObject playerObj)
    {
        Rigidbody rb = playerObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 1. Stop the player's current movement so they don't fight the knockback
            rb.linearVelocity = Vector3.zero;

            // 2. Calculate direction away from the hazard
            Vector3 direction = (playerObj.transform.position - transform.position).normalized;

            // 3. Add upward angle so they fly into the air
            direction.y = 1f;

            // 4. THROW THE PLAYER!
            rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }
}