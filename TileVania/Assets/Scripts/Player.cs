﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    // Messsages and then Methods
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

    void Update()
    {
        Run();
        Jump();
        flipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Value is between -1 to +1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y); // Just use the current rigidbody velocity of y.
        myRigidbody.velocity = playerVelocity; // What Why???

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; // Named the same as the bellow method code even though they are different booleans 
                                                                                          // that are doing the same type of thing.
        if (playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("Running", true); // Rick doesn't use an if stament here but instead just copies in the playerHasHorizontalSpeed in place of true.
                                                // This is less lines but it will likely be changing to an if statement later anyway so I'll keep it around.
        }
    }

    private void Jump() // TODO: if! not jumping jump (this could stop the player being able to jump even when already in the air.)
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
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
