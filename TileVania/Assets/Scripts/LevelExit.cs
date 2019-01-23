using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float LevelLoadDelay = 2f;

    void OnTriggerEnter2D(Collider2D collider2D) // Rick writes other instead. Maybe he doesn't care what Collider2D is called.
    {
        // start coroutine and name the IEnumerator
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        // yield with a delay
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // load next scene
    }

}
