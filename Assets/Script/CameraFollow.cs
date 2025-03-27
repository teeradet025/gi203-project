using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ตัวละครที่ต้องการให้กล้องตาม
    public Vector3 offset = new Vector3(1, 5, -10); // ปรับตำแหน่งกล้องให้ห่างจาก Player

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset; // ตำแหน่งกล้องตามตัวละคร
            transform.LookAt(player); // ทำให้กล้องมองไปที่ Player
        }
    }
}