using UnityEngine;

public class PlatformShakeAndFall : MonoBehaviour
{
    public float shakeDuration = 2f;      // ระยะเวลาการสั่น (วินาที)
    public float shakeIntensity = 0.1f;   // ความรุนแรงของการสั่น
    public float fallDelay = 0.5f;        // เวลาที่พื้นจะร่วงหลังจากสั่น (วินาที)

    private Vector3 initialPosition;      // ตำแหน่งเริ่มต้น
    private bool isShaking = false;       // สถานะการสั่น

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isShaking)
        {
            StartCoroutine(ShakeAndFall());
        }
    }

    private System.Collections.IEnumerator ShakeAndFall()
    {
        isShaking = true;

        // สั่นพื้น
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            randomOffset.y = 0; // ไม่ให้สั่นในแกน Y
            transform.position = initialPosition + randomOffset;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // รออีกนิดก่อนร่วง
        yield return new WaitForSeconds(fallDelay);

        // ปลด Physics (ทำให้ร่วง)
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        // ปิดการชนกันหลังร่วง
        GetComponent<Collider>().enabled = false;

        // ทำลายออบเจ็กต์เมื่อร่วงลง
        Destroy(gameObject, 5f);
    }
}
