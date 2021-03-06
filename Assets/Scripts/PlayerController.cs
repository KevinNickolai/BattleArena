﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // components
    private Rigidbody rigidBody;
    
    public AbilityList abilityList;

    // stats
    public float movementSpeed = 15.0f;
    public float cooldownRate = 1.0f;

    // stuff for character rotation facing mouse
    public float camRayLength = 100.0f;
    public int floorMask;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();

        floorMask = LayerMask.GetMask("Floor");
    }
	
	void FixedUpdate() {
        FaceMouseCursor();

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        transform.Translate(x, 0, z, Space.World);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            abilityList.ReturnAbility(0).UseAbility(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)) {
            abilityList.ReturnAbility(1).UseAbility(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            abilityList.ReturnAbility(2).UseAbility(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            abilityList.ReturnAbility(3).UseAbility(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            abilityList.ReturnAbility(4).UseAbility(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            abilityList.ReturnAbility(5).UseAbility(gameObject);
        }
    }

    void FaceMouseCursor() {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rigidBody.MoveRotation(newRotation);
        }
    }
}
