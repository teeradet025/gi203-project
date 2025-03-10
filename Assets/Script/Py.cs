using UnityEngine;

public class Py : MonoBehaviour
{

    
        public float moveSpeed = 5f; // ความเร็วในการเดิน
        public int maxHealth = 100;  // ค่า HP สูงสุด
        private int currentHealth;   // ค่า HP ปัจจุบัน

        private Rigidbody rb;
        private Vector3 moveDirection;
        private Vector3 spawnPoint;  // จุดเกิด

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // ป้องกันไม่ให้ Rigidbody ล้ม
            rb.freezeRotation = true;

            // ตั้งค่า HP เริ่มต้น
            currentHealth = maxHealth;

            // บันทึกตำแหน่งจุดเกิด
            spawnPoint = transform.position;

            Debug.Log("HP: " + currentHealth);
        }

        void Update()
        {
            // รับข้อมูลการเคลื่อนที่จากปุ่ม WASD
            float moveX = Input.GetAxisRaw("Horizontal"); // A, D หรือ ลูกศรซ้าย, ขวา
            float moveZ = Input.GetAxisRaw("Vertical");   // W, S หรือ ลูกศรขึ้น, ลง

            moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

            // ทดสอบลด HP เมื่อกดปุ่ม "H"
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(10); // ลด 10 HP
            }

            // ทดสอบเพิ่ม HP เมื่อกดปุ่ม "J"
            if (Input.GetKeyDown(KeyCode.J))
            {
                Heal(20); // เพิ่ม 20 HP
            }
        }

        void FixedUpdate()
        {
            // เคลื่อนที่ตามทิศทางที่ได้รับ
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        // ฟังก์ชันลดเลือด
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // จำกัดค่าระหว่าง 0 ถึง maxHealth
            Debug.Log("HP: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        // ฟังก์ชันเพิ่มเลือด
        public void Heal(int healAmount)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // จำกัดค่าระหว่าง 0 ถึง maxHealth
            Debug.Log("HP: " + currentHealth);
        }

        // ฟังก์ชันเมื่อตาย
        void Die()
        {
            Debug.Log("Player Died!");
            Respawn();
        }

        // ฟังก์ชันเกิดใหม่
        void Respawn()
        {
            transform.position = spawnPoint;  // ย้ายตัวละครไปยังจุดเกิด
            currentHealth = maxHealth;        // ฟื้นฟู HP เต็ม
            Debug.Log("Respawned! HP: " + currentHealth);
        }
    }


