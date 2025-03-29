using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static int coinCount = 0;
    public TextMeshProUGUI Goldtext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("เก็บเหรียญแล้ว! เหรียญที่มี: " + coinCount);
            Destroy(other.gameObject);  // ทำลายเหรียญ
            Goldtext.text = "x " + coinCount;
        }
    }
}
