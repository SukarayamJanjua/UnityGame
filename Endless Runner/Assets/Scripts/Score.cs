using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public Text scoreText;

    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 10;
    public int scoreToNextLevel = 10;

    public Text highScore;

    public SwipeDetection swipeDetectionScript;
    public GameObject touchControllerReference;

    public Text scoreTextGameOver;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HS:" + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
        swipeDetectionScript = touchControllerReference.GetComponent<SwipeDetection>();
       
    }

    // Update is called once per frame
    void Update()
    {   //increase difficulty
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime * 1.5f;
        scoreText.text = "Score: "+((int)score).ToString();// converting float to int and then to string
        scoreTextGameOver.text = "Score: " + ((int)score).ToString();
    }
    void LevelUp()
    {   
        if(difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;

        swipeDetectionScript.SetMoveSpeed(difficultyLevel);
    }
    public void SaveScore()
    {   
        if(score > PlayerPrefs.GetFloat("HighScore")){
            PlayerPrefs.SetFloat("HighScore", score);
        }
        
    }
   
    
}
