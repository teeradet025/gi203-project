using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab;  // พรีแฟบกระสุน
    public Transform firePoint;          // ตำแหน่งยิง
    public float projectileMass = 1f;    // มวลกระสุน (m)
    public float acceleration = 10f;     // ความเร่ง (a)
    public int coinsRequired = 3;        // จำนวนเหรียญที่ต้องใช้

    public void FireProjectile()
    {
        if (CoinCollector.coinCount >= coinsRequired)
        {
            // สร้างกระสุน
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // คำนวณแรง (F = m × a)
            Vector3 force = firePoint.forward * (projectileMass * acceleration);

            // เพิ่มแรงให้กระสุน
            rb.mass = projectileMass;
            rb.AddForce(force, ForceMode.Impulse);

            Debug.Log("ยิงกระสุน! แรง: " + force);
        }
        else
        {
            Debug.Log("เหรียญไม่ครบ! ต้องการ: " + coinsRequired);
        }
    }
}
