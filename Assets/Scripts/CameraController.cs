using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    private Transform thisTransform;
    public float distance = 18.5f;
    public float offset = 14.0f;

	// Use this for initialization
	void Start () {
        thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        thisTransform.position = new Vector3 (target.position.x, target.position.y + distance, target.position.z - offset);
    }
}
