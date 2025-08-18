using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Creates vars for the score and score text display
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI AccuracyText;

    public TextMeshProUGUI HighscoreText;
    // Ints for score and accuracy tracking
    int score = 0;
    public static int highscore = 0;
    float accuracy = 0;
    int hits = 0;
    int fired = 0;
    public static ScoreController Instance;
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Creates the text for each ui value
    void Start()
    {   

        ScoreText.text = "Score:" + score.ToString();
        AccuracyText.text = "Accuracy:" + accuracy.ToString();
        HighscoreText.text = "Highscore:" + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {   
        //Adds 1 to the score and changes the text
        score = score + 1;
        ScoreText.text = "Score:" + score.ToString();

        //Updates highscore if score exceeds it
        if (score > highscore)
        {
            highscore = score;
            HighscoreText.text = "Highscore:" + highscore.ToString();
        }

    }

    public void CalcAccuracy(string type)
    {
        //Uses strcmp to determine if hit or fire, then calcs accuracy and gives value to UI
        if (type == "hit")
        {
            hits += 1;
        }
        else if (type == "fired")
        {
            fired += 1;
        }
        accuracy = (float)hits / fired * 100;
        //Casting to float suggested by copilot
        accuracy = MathF.Round(accuracy);
        AccuracyText.text = "Accuracy" + accuracy.ToString() + "%";
    }


}
