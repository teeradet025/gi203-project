using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : MonoBehaviour
{
    public float speed = 3f;
    public float visionDistance = 10f;
    public Transform player;

    void Update()
    {
        // คำนวณระยะห่างระหว่างบอทกับผู้เล่น
        float distance = Vector3.Distance(transform.position, player.position);

        // ตรวจสอบว่าผู้เล่นอยู่ในระยะการมองเห็นหรือไม่
        if (distance <= visionDistance)
        {
            // วิ่งตามผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player); // หมุนบอทให้หันหน้าหาผู้เล่น
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Caught! Restarting...");
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // เริ่มด่านใหม่
    }
}
