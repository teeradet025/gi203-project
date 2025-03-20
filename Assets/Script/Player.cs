using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // รับค่าการเคลื่อนที่จากปุ่ม WASD
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // สร้างเวกเตอร์ทิศทางการเคลื่อนที่
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        // ถ้ามีการเคลื่อนที่ให้หมุนตัวละครตามทิศทาง
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // กระโดด
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // รีเซ็ตฉากเมื่อชนบอท
        if (collision.gameObject.CompareTag("Bot"))
        {
            Debug.Log("Hit by Bot! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int coinCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("Coin Collected! Total: " + coinCount);
            Destroy(other.gameObject);
        }
    }
}