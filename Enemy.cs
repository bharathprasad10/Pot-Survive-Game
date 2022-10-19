using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float minDistance = 1f;
    public GameObject enemyDeathEffect;
    private PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameObject enemy = this.gameObject;
        Destroy(enemy, 20f);
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore.health > 0)
        {
            if (Vector2.Distance(target.position, transform.position) >= minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(target.position, transform.position) < minDistance - .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * 2 * Time.deltaTime);

            }
        }
        



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            playerScore.score++;
            string[] enemySounds = { "EnemyDeath1", "EnemyDeath2", "EnemyDeath3" };
            int rand = Random.Range(0, enemySounds.Length);

            SoundManager.PlaySound(enemySounds[rand]);

            //FindObjectOfType<AudioManager>().Play(enemySounds[rand]);
           GameObject effect = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(effect, 2f);
        }
            
        
    }
}
