using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject bulletPrefab;    // กระสุนที่ยิงออกมา
    public Transform firePoint;        // ตำแหน่งยิง
    public float bulletSpeed = 10f;    // ความเร็วกระสุน
    public float shootInterval = 0.5f; // เวลาระหว่างการยิง (0.5 วินาที)

    void Start()
    {
        // เรียกฟังก์ชัน Shoot ซ้ำ ๆ ทุก 0.5 วินาที
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    void Shoot()
    {
        // สร้างกระสุนที่ตำแหน่งยิง
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        Debug.Log("Bot ยิงกระสุน!");
    }
}
