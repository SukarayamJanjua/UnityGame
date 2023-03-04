using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CollisionManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject collisionHurtUI;
    public GameObject pauseMenuUI;
    
    public PauseMenu pauseMenuScript;

    private Animator myAnimator;
    private Movement movementScript;
    
    public Text livesText;

    public float timeToDelay = 1.5f;
    public int lives = 5;

    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);
    public ParticleSystem collisionParticles;

    public AudioSource audioSource;
    public AudioClip powerUpSound;
    public AudioClip explosionSound;
    public AudioClip gameOverSound;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        movementScript = GetComponent<Movement>();
        pauseMenuScript = GetComponent<PauseMenu>();
        livesText.text = lives.ToString("0"); 
    }
    void Update()
    {
        if(transform.position.y < -3f)
        {
            Invoke("Restart", timeToDelay);
            myAnimator.SetBool("IsDead", true);
            movementScript.enabled = false;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0.6f;
            
            collisionHurtUI.SetActive(true);
             lives -= 1;
            
            livesText.text = lives.ToString("0");
            
            if (lives > 0)
            {
                Destroy(other.gameObject);
                audioSource.PlayOneShot(explosionSound);

                //Instantiate(collisionParticles, playerTransform.position + offset, playerTransform.rotation);
            }
            
            Instantiate(collisionParticles, playerTransform.position + offset, playerTransform.rotation);
           
            //Destroy(spawnParticls, 4f);
            Invoke("toNormalSpeed",0.6f);
            
            //Destroy(collisionParticles, 4f);
            
            if (lives <= 0)//means game has ended(player dead)
            {
                //collisionHurtUI.SetActive(false);
                livesText.text = "0";
                Instantiate(collisionParticles, playerTransform.position + offset, playerTransform.rotation);
                Instantiate(collisionParticles, playerTransform.position + offset, playerTransform.rotation);
                myAnimator.SetBool("IsDead", true);
                movementScript.enabled = false;
                GetComponent<Score>().SaveScore();
                GetComponent<Coins>().SaveCoins();
                //GetComponent<Coins>().GameEnded();
                //Invoke("Restart", timeToDelay);   
                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
                //G?audioSource.Stop();
                audioSource.PlayOneShot(gameOverSound);


            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LivesPowerUp"))
        {
            lives += 1;
            livesText.text = lives.ToString("0");
            Destroy(other.gameObject);
            audioSource.PlayOneShot(powerUpSound);
        }
       
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }
    public void Back()
    {
        //if (gameOverUI)
        //{
        //    gameOverUI.SetActive(false);
        //}
        //if (pauseMenuUI)
        //{
        //    pauseMenuUI.SetActive(false);
        //}

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GetComponent<Score>().SaveScore();
        GetComponent<Coins>().SaveCoins();
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        if(pauseMenuScript.gameIsPaused == true)
        {
            pauseMenuScript.gameIsPaused = false;

        }

    }
    
    void toNormalSpeed()
    {
        Time.timeScale = 1f;
        collisionHurtUI.SetActive(false);
    }
 
    
    
}
