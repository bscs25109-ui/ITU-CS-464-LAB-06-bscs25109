
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int max = 3;
    int current;

    void Awake()
    {
        current = max;
    }

    public bool TakeDamage(int amount)
    {
        if (current <= 0) return false;

        current -= amount;
        Debug.Log("Player health: " + current);

        if (current <= 0)
        {
            Debug.Log("Player defeated!");
        }

        return true;
    }
}
