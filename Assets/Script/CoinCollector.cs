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
            Debug.Log("������­����! ����­�����: " + coinCount);
            Destroy(other.gameObject);  // ���������­
            Goldtext.text = "x " + coinCount;
        }
    }
}
