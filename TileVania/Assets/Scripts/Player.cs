using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;

    Rigidbody2D myRigidbody;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        Run();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Value is between -1 to +1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y); // Just use the current rigidbody velocity of y.
        myRigidbody.velocity = playerVelocity; // What Why???
    }
}
