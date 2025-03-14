using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // บันทึกตำแหน่งเช็คพอยต์ล่าสุด
            PlayerRespawn.lastCheckpointPosition = transform.position;
            Debug.Log("Checkpoint Updated: " + transform.position);
        }
    }
}