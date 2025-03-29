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
        rb.freezeRotation = true; // ��ͧ�ѹ�����ع�������ͧ���
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // �Ѻ��ҡ������͹���ҡ���� WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ���ҧ�ǡ�����ȷҧ�������͹���
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed;

        // �� velocity ��������͹���
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // ����ա������͹��������ع����Фõ����ȷҧ
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
        }
    }

    void Update()
    {
        // ���ⴴ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }

        // ����ҵ����������� (���᡹ Y ���¡��� -10)
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

        // ���絩ҡ����ͪ��ͷ
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