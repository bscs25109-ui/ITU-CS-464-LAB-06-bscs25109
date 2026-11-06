using UnityEngine;

public class Level2ExitZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // If the player touches this green box, find the Manager and tell it we won!
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Level2Manager>().TriggerWin();
        }
    }
}