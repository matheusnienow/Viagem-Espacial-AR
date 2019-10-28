using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour {

    [Range(3, 360)]
    public int Segments = 3;
    public float InnerRadius = 1.5f;
    public float Thickness = 0.5f;
    public Material RingMat;

    private GameObject ring;
    private Mesh ringMesh;
    private MeshFilter ringMF;
    private MeshRenderer ringMR;

	// Use this for initialization
	void Start () {
        //create ring object
        ring = new GameObject(name+" Ring");
        ring.transform.parent = this.transform;
        ring.transform.localScale = Vector3.one;
        ring.transform.localPosition = Vector3.zero;
        ring.transform.rotation = Quaternion.identity;

        ringMF = ring.AddComponent<MeshFilter>();
        ringMesh = ringMF.mesh;
        ringMR = ring.AddComponent<MeshRenderer>();
        ringMR.material = RingMat;

        //build ring mesh
        Vector3[] vertices = new Vector3[(Segments + 1) * 2 * 2];
        int[] triangles = new int[Segments * 6 * 2];
        Vector2[] uv = new Vector2[(Segments + 1) * 2 * 2];
        int halfway = (Segments + 1) * 2;

        for (int i = 0; i < Segments + 1; i++)
        {
            float progress = i / Segments; 
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (InnerRadius  + Thickness);
            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * InnerRadius;
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f);

            if (i != Segments)
            {
                triangles[i * 12] = i *  2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i + 2 * 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i + 2 * 1 + halfway;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
            }
        }

        ringMesh.vertices = vertices;
        ringMesh.triangles = triangles;
        ringMesh.uv = uv;
        ringMesh.RecalculateNormals();
	}
}
