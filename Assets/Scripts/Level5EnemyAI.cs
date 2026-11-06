using UnityEngine;

public class Level5EnemyAI : MonoBehaviour
{
    public Transform[] points;
    public float patrolSpeed = 2f;
    public float waitTime = 0.5f;
    public Transform player;
    public float chaseRange = 7f;
    public float chaseSpeed = 4.5f;
    public float catchRadius = 1.3f;

    private int index = 0;
    private float waitUntil;

    void Update()
    {
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= catchRadius)
        {
            FindObjectOfType<Level5Manager>()?.TriggerLose("Enemy caught you!");
            return;
        }

        if (distanceToPlayer <= chaseRange) ChasePlayer();
        else Patrol();
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        transform.position += direction * chaseSpeed * Time.deltaTime;
        if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction);
    }

    void Patrol()
    {
        if (Time.time < waitUntil || points.Length == 0) return;
        Vector3 target = points[index].position;
        Vector3 toTarget = target - transform.position;
        toTarget.y = 0;

        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);
        if (toTarget != Vector3.zero) transform.rotation = Quaternion.LookRotation(toTarget);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            index = (index + 1) % points.Length;
            waitUntil = Time.time + waitTime;
        }
    }
}