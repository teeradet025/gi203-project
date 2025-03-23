using UnityEngine;

public class TapTrigger : MonoBehaviour
{
    public CannonController cannonController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("เหยียบ Tap แล้ว! ตรวจสอบเหรียญ...");
            cannonController.FireProjectile();
        }
    }
}
