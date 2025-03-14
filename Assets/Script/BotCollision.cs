using UnityEngine;

public class BotCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // เรียกฟังก์ชัน Respawn ใน PlayerRespawn.cs
            collision.gameObject.GetComponent<PlayerRespawn>().Respawn();
            Debug.Log("Bot hit player! Respawning...");
        }
    }
}
