using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        // Add to score.
        // Create/Play SFX.
    }

}
