using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBehavior : MonoBehaviour {

    public GameObject planetTarget;
    private Transform center;    
    public Vector3 axis = Vector3.up;
    public float radius = 10f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 40.0f;

    // Use this for initialization
    void Start () {
        center = planetTarget.transform;
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    void Update()
    {
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
