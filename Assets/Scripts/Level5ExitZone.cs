using UnityEngine;

public class Level5ExitZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Level5Manager manager = FindObjectOfType<Level5Manager>();
            if (manager != null)
            {
                if (manager.CurrentScore >= manager.targetScore)
                    manager.TriggerWin();
            }
        }
    }
}