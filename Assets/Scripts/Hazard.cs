using System.Collections;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float knockback = 6f;

    // Pulsing hazard timings (leave restTime = 0 for an always-on hazard)
    [SerializeField] float restTime = 0f;   // safe phase
    [SerializeField] float warnTime = 0.7f; // warning visible, still safe
    [SerializeField] float strikeTime = 0.4f; // collider ON — dangerous

    [SerializeField] GameObject warning;        // child object shown as warning

    // Start is a coroutine — only runs the loop when restTime > 0
    IEnumerator Start()
    {
        if (restTime <= 0f) yield break;        // always-on: nothing to cycle

        Collider zone = GetComponent<Collider>();

        while (true)
        {
            // ── REST phase ─────────────────────────────
            zone.enabled = false;
            yield return new WaitForSeconds(restTime);

            // ── WARN phase ─────────────────────────────
            warning.SetActive(true);
            yield return new WaitForSeconds(warnTime);

            // ── STRIKE phase ───────────────────────────
            warning.SetActive(false);
            zone.enabled = true;
            yield return new WaitForSeconds(strikeTime);
        }
    }

    // Fires every physics frame while the player stays inside the trigger
    void OnTriggerStay(Collider other)
    {
        // TryGetComponent returns false if no Health on this collider — skip
        if (!other.TryGetComponent(out Health health) || !health.TakeDamage(damage)) return;

        // Push the player away from the hazard's centre
        Rigidbody body = other.attachedRigidbody;
        Vector3 away = body.position - transform.position;
        away.y = 0f;                   // keep knockback horizontal
        body.AddForce(away.normalized * knockback, ForceMode.Impulse);
    }
}