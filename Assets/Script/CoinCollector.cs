using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("เก็บเหรียญแล้ว! เหรียญที่มี: " + coinCount);
            Destroy(other.gameObject);  // ทำลายเหรียญ
        }
    }
}
