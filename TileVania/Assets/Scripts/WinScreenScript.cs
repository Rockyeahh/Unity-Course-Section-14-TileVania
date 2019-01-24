using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenScript : MonoBehaviour {

    //[SerializeField] Button winButton;
    //[SerializeField] Text winText;
    [SerializeField] Canvas canvasObject;
    [SerializeField] Animator myAnimator;

    private void Start()
    {
        //winButton = GetComponent<Button>();
        // winText = GetComponent<Text>();
        //winButton.SetActive(false);
        //canvasObject = GetComponent<Canvas>();
        //canvasObject.enabled = false;

        //Find the object you're looking for
        GameObject canvasGameObject = GameObject.Find("EscapeCanvas");
        if (canvasGameObject != null)
        {
            //If we found the object , get the Canvas component from it.
            canvasObject = canvasGameObject.GetComponent<Canvas>();
            if (canvasObject == null)
            {
                Debug.Log("Could not locate Canvas component on " + canvasGameObject.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject canvasGameObject = GameObject.Find("EscapeCanvas");
        print("collision");
       // if (canvasGameObject.SetActive = false)
        //{
            print("canvas enabled");
        print("FINISH THIS LATER");
        //canvasGameObject.SetActive(true);
        //        }

        //canvasObject.SetActive(false);

        // todo: Add in a way for the Cinemachine to react to this trigger and zoom out the camera. Use a animation state. Call it the Win State. 
        // Then use a transtion time between the two states.
        myAnimator.SetTrigger("Win");
        // Todo: Disable the player movement.

    }

}
