using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ป้องกันการหมุนที่ไม่ต้องการ
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // รับค่าการเคลื่อนที่จากปุ่ม WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // สร้างเวกเตอร์ทิศทางการเคลื่อนที่
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed;

        // ใช้ velocity เพื่อเคลื่อนที่
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // ถ้ามีการเคลื่อนที่ให้หมุนตัวละครตามทิศทาง
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
        }
    }

    void Update()
    {
        // กระโดด
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        // เช็คว่าตกแมพหรือไม่ (ถ้าแกน Y น้อยกว่า -10)
        if (transform.position.y < -10)
        {
            Debug.Log("Player fell off the map! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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