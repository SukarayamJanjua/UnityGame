using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Text highScore;
    
    public Text totalCoinsCount;
    public AudioSource audioSource;

    public GameObject gameOverUI;
    void Start()
    {
        
        //Display high Score on Main Menu
        highScore.text = "HighScore:"+((int)PlayerPrefs.GetFloat("HighScore")).ToString();
        totalCoinsCount.text = "TotalCoins: "+ PlayerPrefs.GetInt("TotalCoinsCount").ToString();
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
