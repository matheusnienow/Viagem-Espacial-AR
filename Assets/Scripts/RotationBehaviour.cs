using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour {
    
    [Range(1, 20)]
    public int speed = 10;
    
	// Use this for initialization
	void Start () {
        Debug.Log("está funcionando");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down * speed * Time.deltaTime, Space.World);
	}
}
