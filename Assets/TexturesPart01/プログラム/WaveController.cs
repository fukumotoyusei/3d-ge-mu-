using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaveController : MonoBehaviour
{
    public float waveHeight = 0.2f; // 波の高さ
    public float waveFrequency = 1.0f; // 波の頻度
    public float waveSpeed = 1.0f; // 波の速さ

    private Mesh mesh;
    private Vector3[] baseVertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[baseVertices.Length];
        float time = Time.time * waveSpeed;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseVertices[i];
            vertex.y += Mathf.Sin(vertex.x * waveFrequency + time) * waveHeight;
            vertex.y += Mathf.Sin(vertex.z * waveFrequency + time) * waveHeight;
            vertices[i] = vertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals(); // 法線を再計算
        mesh.RecalculateBounds(); // 境界を再計算
    }
}
