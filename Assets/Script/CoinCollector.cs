using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoinCollector : MonoBehaviour
{
    public static int coinCount = 0;
   
    public TextMeshProUGUI textcoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("Get Coin: " + coinCount);
            Destroy(other.gameObject);  // ทำลายเหรียญ
        }
    }
    public void Update()
    {
        textcoin.text = "X " + coinCount;
    }

}
