using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 500f;
    public float bounceSpeed = 2f;
    public float bounceHeight = 0.25f;

    private Vector3 startPos;

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของเหรียญ
        startPos = transform.position;
    }

    void Update()
    {
        // การหมุนเหรียญรอบแกน Y
        Debug.Log("Coin is rotating");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // การกระเด้งขึ้นลง (ทำให้ดูมีชีวิตชีวา)
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
