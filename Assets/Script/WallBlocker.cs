using UnityEngine;

public class WallBlocker : MonoBehaviour
{
    public Player player; // อ้างอิงไปที่ Player เพื่อดูจำนวนเหรียญที่เก็บได้
    public int requiredCoins = 5; // จำนวนเหรียญที่ต้องมีเพื่อเปิดกำแพง

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.coinCount >= requiredCoins)
            {
                Debug.Log("เปิดทางผ่าน!");
                Destroy(gameObject); // ทำลายกำแพง (เปิดทาง)
            }
            else
            {
                Debug.Log("ยังเก็บเหรียญไม่ครบ! ต้องการ " + requiredCoins + " เหรียญ");
            }
        }
    }
}
