using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinWorth = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position); // TODO: Fix this!
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(coinWorth);
        // coinWorth + PointsToAdd or maybe try = or calling the whole method. Maybe I need to find method. Ahhhh.
        // Add to score.
    }

}
