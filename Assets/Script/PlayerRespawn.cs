using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static Vector3 lastCheckpointPosition;

    private void Start()
    {
        // เริ่มต้นที่ตำแหน่งแรก (กรณีเริ่มเกม)
        lastCheckpointPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = lastCheckpointPosition;
        Debug.Log("Respawn at: " + lastCheckpointPosition);
    }

    private void Update()
    {
        // ทดสอบด้วยปุ่ม R เพื่อตายและกลับไปยังเช็คพอยต์
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
