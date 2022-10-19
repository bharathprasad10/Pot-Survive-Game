using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireSpawner : MonoBehaviour
{

    public float startTimeBtwnBullets;
    private PlayerScore playerScore;

    public GameObject enemyBullet;
    float timeBtwnBullets;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwnBullets = startTimeBtwnBullets;
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore.health > 0)
        {
            if (timeBtwnBullets <= 0f)
            {
                Instantiate(enemyBullet, transform.position, Quaternion.identity);
                timeBtwnBullets = startTimeBtwnBullets;
            }
            else
            {
                timeBtwnBullets -= Time.deltaTime;
            }
        }
        

       
    }
}
