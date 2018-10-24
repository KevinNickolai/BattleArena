using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour {

    // components
    private Transform thisTransform;

    // store prefabs here to allow skill the ability to instantiate them
    public GameObject bulletPrefab;
    // public Transform bulletSpawn;

    void Start () {
        thisTransform = GetComponent<Transform>();
	}
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            ShootTheArrow();
        }
    }

    void ShootTheArrow() {
        Console.WriteLine("Shooting an arrow");

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            thisTransform.position,
            thisTransform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 35;

        Destroy(bullet, 2.0f);
    }
}
