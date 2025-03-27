using UnityEngine;
using UnityEngine.AI;

public class SnowZone : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วปกติ
    public float jumpForce = 7f; // แรงกระโดดปกติ
    private float defaultSpeed; // เก็บค่าความเร็วเดิม
    private float defaultJump; // เก็บค่าแรงกระโดดเดิม

    private Rigidbody rb;
    private NavMeshAgent agent; // สำหรับ Bot

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>(); // ใช้สำหรับ Bot

        // บันทึกค่าปกติ
        defaultSpeed = moveSpeed;
        defaultJump = jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snow")) // ถ้าสัมผัสพื้นที่หิมะ
        {
            moveSpeed -= 2; // ลดความเร็ว 2 หน่วย
            jumpForce -= 2; // ลดแรงกระโดด 2 หน่วย

            if (agent != null) // ถ้าเป็น Bot (มี NavMeshAgent)
            {
                agent.speed -= 2; // ลดความเร็วของ Bot ด้วย
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Snow")) // ถ้าออกจากพื้นที่หิมะ
        {
            moveSpeed = defaultSpeed; // คืนค่าความเร็วเดิม
            jumpForce = defaultJump; // คืนค่าแรงกระโดดเดิม

            if (agent != null) // ถ้าเป็น Bot
            {
                agent.speed = defaultSpeed; // คืนค่าความเร็วเดิมของ Bot
            }
        }
    }
}

