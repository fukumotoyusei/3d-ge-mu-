using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float waterLevel = 0f; // 海面の高さ
    public float buoyancyFactor = 1f; // 浮力の強さ

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float depth = waterLevel - transform.position.y;
        if (depth > 0)
        {
            rb.AddForce(Vector3.up * depth * buoyancyFactor, ForceMode.Acceleration);
        }
    }
}
