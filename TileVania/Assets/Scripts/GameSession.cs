using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0; // Even without 0 here a int initialises at 0. As we start counting from 0.

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length; // Finds how many game sessions there are in the scene.
        if (numGameSessions < 1)
        {
            Destroy(gameObject); // Destroys new game object because one already exists.
        }
        else
        {
            DontDestroyOnLoad(gameObject); // This stops it destroying all game session gameobjects, keeps this instance going, thus not resetting data like the score.
        }
    }

    // Use this for initialization
    void Start () {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
	}

    public void AddToScore(int pointsToAdd) // Rick says that having int pointsToAdd here is good. He said "A rambled paragraph, and I've kept it in the notes doc under Persistent Score & Lives".
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath() // Keep public so that other scripts/classes can trigger player death.
    {
        if (playerLives > 1) // maybe > 0
        {
            TakeLife();
        } else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        Scene currentScene = SceneManager.GetActiveScene(); // Can also be done with ().buldindex and no .name bellow.
        SceneManager.LoadScene(currentScene.name); // .name just tells it to load the scene named currentScene rather than by number.
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject); // Destroys game session in order to reset score due to lack of any remaining lives.
        // Do the lives/score need resetting when you lose and/or close and reopen the game?
    }
}
