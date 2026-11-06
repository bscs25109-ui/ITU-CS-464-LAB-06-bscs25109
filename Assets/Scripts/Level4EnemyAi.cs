//using UnityEngine;

//public class Level4EnemyAI : MonoBehaviour
//{
//    [Header("Patrol Settings (When player is far)")]
//    public Transform[] points;
//    public float patrolSpeed = 2f;
//    public float waitTime = 0.5f;

//    [Header("Chase Settings (When player is close)")]
//    public Transform player;           // Drag your Player object here
//    public float chaseRange = 6f;      // How close the player needs to be to trigger the chase
//    public float chaseSpeed = 4f;      // The enemy moves faster when chasing

//    private int index = 0;
//    private float waitUntil;
//    private bool isChasing = false;

//    void Update()
//    {
//        if (player == null) return;

//        // Calculate how far away the player is
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        // If the player is within the chase range, chase them!
//        if (distanceToPlayer <= chaseRange)
//        {
//            isChasing = true;
//        }
//        else
//        {
//            isChasing = false;
//        }

//        if (isChasing)
//        {
//            ChasePlayer();
//        }
//        else
//        {
//            Patrol();
//        }
//    }

//    void ChasePlayer()
//    {
//        // Move towards the player
//        Vector3 direction = (player.position - transform.position).normalized;
//        direction.y = 0; // Keep the enemy on the floor
//        transform.position += direction * chaseSpeed * Time.deltaTime;

//        // Face the player
//        if (direction != Vector3.zero)
//            transform.rotation = Quaternion.LookRotation(direction);
//    }

//    void Patrol()
//    {
//        if (Time.time < waitUntil || points.Length == 0) return;

//        Vector3 target = points[index].position;
//        Vector3 toTarget = target - transform.position;
//        toTarget.y = 0;

//        // Move towards the waypoint
//        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

//        // Face the waypoint
//        if (toTarget != Vector3.zero)
//            transform.rotation = Quaternion.LookRotation(toTarget);

//        // If we reached the waypoint, wait and move to the next one
//        if (Vector3.Distance(transform.position, target) < 0.1f)
//        {
//            index = (index + 1) % points.Length;
//            waitUntil = Time.time + waitTime;
//        }
//    }

//    // This draws a red circle in the Scene view so you can see the chase range
//    void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, chaseRange);
//    }
//}
using UnityEngine;

public class Level4EnemyAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] points;
    public float patrolSpeed = 2f;
    public float waitTime = 0.5f;

    [Header("Chase Settings")]
    public Transform player;
    public float chaseRange = 6f;
    public float chaseSpeed = 4f;

    [Header("Catch Settings")]
    public float catchRadius = 1.3f; // If they get this close, you lose!

    private int index = 0;
    private float waitUntil;
    private bool isChasing = false;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if caught
        if (distanceToPlayer <= catchRadius)
        {
            Level4Manager manager = FindObjectOfType<Level4Manager>();
            if (manager != null)
            {
                manager.TriggerLose("You Lose! Enemy caught you!");
            }
            return; // Stop running the rest of the code
        }

        // Chase logic
        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing) ChasePlayer();
        else Patrol();
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        transform.position += direction * chaseSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }

    void Patrol()
    {
        if (Time.time < waitUntil || points.Length == 0) return;

        Vector3 target = points[index].position;
        Vector3 toTarget = target - transform.position;
        toTarget.y = 0;

        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

        if (toTarget != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(toTarget);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            index = (index + 1) % points.Length;
            waitUntil = Time.time + waitTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Red circle for chase range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        // Yellow circle for catch radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, catchRadius);
    }
}