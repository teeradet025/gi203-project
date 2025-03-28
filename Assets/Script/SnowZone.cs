using UnityEngine;
using UnityEngine.AI;

public class SnowZone : MonoBehaviour
{
    public float slideForce = 5f; // กำหนดแรงลื่น

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0.1f) // เช็คว่ากำลังเคลื่อนที่
        {
            Vector3 slide = rb.velocity.normalized * slideForce;
            rb.AddForce(slide, ForceMode.Acceleration);
        }
    }
}

