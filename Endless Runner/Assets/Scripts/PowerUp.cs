using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpLive;
    public GameObject powerUpTenCoins;
    
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0,1,100);

    

    // Update is called once per frame
    void Update()
    {
        //SpawnLivePowerUp();
        Invoke("SpawnLivePowerUp", 0.4f);
        //Invoke("SpawnDoubleJumpPowerUp", 2f);
        Invoke("SpawnTenCoinsPowerUp", 0.4f);
    }

    void SpawnLivePowerUp()
    {
        if (playerTransform.position.z % 450 <= 0.1f && Time.time > 10f)
        {
            GameObject spawnLive = Instantiate(powerUpLive, playerTransform.position + offset, playerTransform.rotation);
            Destroy(spawnLive, 700f);
        }
    }
    void SpawnTenCoinsPowerUp()
    {
        if(playerTransform.position.z % 150 <= 0.1f && Time.time > 10f)
        {
            GameObject spawnTenCoins = Instantiate(powerUpTenCoins, playerTransform.position + offset, playerTransform.rotation);
            Destroy(spawnTenCoins, 500f);
        }
    }
}
