using UnityEngine;

public class Level5Hazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FindObjectOfType<Level5Manager>()?.TriggerLose("You touched a hazard!");
    }
}