using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int coinsCount = 0;
    public Text coinsCountText;


    public AudioClip coinsSound;
    public AudioClip tenCoinsSound;
    public AudioSource audioSource;

    public Text coinsCountGameOver;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        coinsCountText.text = coinsCount.ToString();
        coinsCountGameOver.text = "Coins: " + coinsCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCount += 1;
            //GetComponent<AudioManager>().CoinsSound();
            audioSource.PlayOneShot(coinsSound);
            Destroy(other.gameObject);
        }
        
        
        if (other.gameObject.CompareTag("PlusTenCoins"))
        {
            coinsCount += 10;
            audioSource.PlayOneShot(tenCoinsSound);
            Destroy(other.gameObject);
        }
    }
    public void GameEnded()
    {
        //
    }
    public void SaveCoins()
    {
        int currentCoins = PlayerPrefs.GetInt("TotalCoinsCount");
        currentCoins += coinsCount;
        
        PlayerPrefs.SetInt("TotalCoinsCount", currentCoins);
    }
    
}
