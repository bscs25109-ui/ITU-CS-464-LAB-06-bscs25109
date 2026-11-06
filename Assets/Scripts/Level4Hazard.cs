using UnityEngine;

public class Level4Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Level4Manager manager = FindObjectOfType<Level4Manager>();
            if (manager != null)
            {
                manager.TriggerLose("You Lose! You touched a hazard!");
            }
        }
    }
}