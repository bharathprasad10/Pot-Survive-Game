using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    //public Enemy enemy;

    public GameObject gameoverObject;
    public GameObject playerDeathEffect;
    public Animator animator;

    public Text life;
    public Text scorePoints;
    public Text highScore;
    public Image[] hearts;

    public int score;
    int tempScore;
    public int numOfHearts;

    SpriteRenderer[] sprite;
    private Shooting shooting;
    public float health = 3;
    float damage = 1;
    bool effectBool;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentsInChildren<SpriteRenderer>();
        shooting = GetComponentInChildren<Shooting>();
        effectBool = true;
        tempScore = score;

        highScore.text = PlayerPrefs.GetInt("HS", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if( health <= 0)
        {
            

            while (effectBool)
            {
                GameObject effect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity) as GameObject;
                Destroy(effect, 5f);
                effectBool = false;
                //FindObjectOfType<AudioManager>().Play("GameOver");
            }
            
            GetComponent<Collider2D>().enabled = false;
            shooting.enabled = false;
            for(int i =0; i < sprite.Length; i++)
            {
                sprite[i].enabled = false;
            }

            gameoverObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }

        //life.text = "LIFE: " + health.ToString();
        scorePoints.text = score.ToString();

        animateCameraShake();
        DisplayHearts();
    }

    private void LateUpdate()
    {
        if(score > PlayerPrefs.GetInt("HS", 0))
        {
            PlayerPrefs.SetInt("HS", score);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemybullet")
        {
            health -= damage;
            Debug.Log("Health " + health);
            //FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }

    void animateCameraShake()
    {
        if(tempScore != score)
        {
            animator.SetTrigger("Shake");
            tempScore = score;
        }
    }

    void DisplayHearts()
    {
        switch (health)
        {
            case 0: hearts[0].enabled = false;
                hearts[1].enabled = false;
                hearts[2].enabled = false;
                break;

            case 1:
                hearts[0].enabled = true;
                hearts[1].enabled = false;
                hearts[2].enabled = false;
                break;
            case 2:
                hearts[0].enabled = true;
                hearts[1].enabled = true;
                hearts[2].enabled = false;
                break;
            case 3:
                hearts[0].enabled = true;
                hearts[1].enabled = true;
                hearts[2].enabled = true;
                break;

            default:
                hearts[0].enabled = false;
                hearts[1].enabled = false;
                hearts[2].enabled = false;
                break;
        }
    }

    
}
