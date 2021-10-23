using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller bs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scoreMulti = 1;

    public Text scoreText;
    public Text multiText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize reference to self
        instance = this;
        // Initialize appropriate score texts
        scoreText.text = "Score: 0";
        multiText.text = "Multiplier: x1";
    }

    // Update is called once per frame
    void Update()
    {
        // Don't start playing until input is received
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                // Start the game
                startPlaying = true;
                bs.hasStarted = true;
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time!");
        // Increment and update multiplier
        scoreMulti += 1;
        multiText.text = "Multiplier: x" + scoreMulti;
        // Increment and update score
        currentScore += scorePerNote * scoreMulti;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("You missed!");
        // Reset the multiplier
        scoreMulti = 1;
        multiText.text = "Multiplier: x" + scoreMulti;
    }
}
