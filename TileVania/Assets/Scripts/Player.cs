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
        flipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Value is between -1 to +1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y); // Just use the current rigidbody velocity of y.
        myRigidbody.velocity = playerVelocity; // What Why???
    }

    private void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; // Mathf.Epsilon is the smallest float.
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f); // How does adding this line flip the sprite depending on the direction it is moving in?
        }
    }

}
