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
    public int scorePerGood = 125;
    public int scorePerPerfect = 150;
    public int scoreMulti = 1;

    public int[] multiThresholds;
    public int noteStreak;

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
        // Increment and update multiplier
        noteStreak++;
        if(noteStreak == multiThresholds[scoreMulti])
        {
            scoreMulti += 1;
            multiText.text = "Multiplier: x" + scoreMulti;
        }
        
        // Increment and update score
        // currentScore += scorePerNote * scoreMulti;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit() 
    {
        currentScore += scorePerNote * scoreMulti;
        NoteHit();
    }

    public void GoodHit() 
    {
        currentScore += scorePerGood * scoreMulti;
        NoteHit();
    }

    public void PerfectHit() 
    {
        currentScore += scorePerPerfect * scoreMulti;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("You missed!");
        // Reset the multiplier
        noteStreak = 0;
        scoreMulti = 1;
        multiText.text = "Multiplier: x" + scoreMulti;
    }
}
