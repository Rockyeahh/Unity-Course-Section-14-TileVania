using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2 (25f, 25f); // This is supposed to throw the player up in the air?

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBody;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    // Messsages and then Methods
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
	}

    void Update()
    {
        if (!isAlive) { return; }

        Run();
        Jump();
        flipSprite();
        ClimbLadder();
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
        else { myAnimator.SetBool("Running", false); }
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }

    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"))) { // Maybe this needs it's own collider like the Jump method?
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
            return; }

        float controlThrowClimb = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrowClimb * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Die();
        }
    }

    private void Die() // Maybe the physics need to be stopped while the animation does it's thing.
    {
        isAlive = false;
        myAnimator.SetTrigger("Dying");
        myRigidbody.velocity = deathKick;
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
