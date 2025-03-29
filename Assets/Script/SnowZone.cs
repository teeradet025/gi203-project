using UnityEngine;
using UnityEngine.AI;

public class SnowZone : MonoBehaviour
{
    public float slideForce = 5f; // ��˹��ç���

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 0.1f) // ����ҡ��ѧ����͹���
        {
            Vector3 slide = rb.linearVelocity.normalized * slideForce;
            rb.AddForce(slide, ForceMode.Acceleration);
        }
    }
}

