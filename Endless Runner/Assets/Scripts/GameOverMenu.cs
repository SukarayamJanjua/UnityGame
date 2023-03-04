using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{   public static bool gameIsOver = false;
    //public Text displayScore;
    //public Text displayCoins;

    //public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //displayScore.text = "Score: " + (GetComponent<Score>().score).ToString();
        //displayCoins.text = "Coins: " + GetComponent<Coins>().coinsCount.ToString();

    }
    public void RetryGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //GetComponent<Score>().SaveScore();
        //GetComponent<Coins>().SaveCoins();
        Time.timeScale = 1f;
    }
}
