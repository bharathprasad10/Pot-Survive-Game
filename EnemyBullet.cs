using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    private Collider2D bulletCol;
    private Collider2D enemyCol;
    public Rigidbody2D rb;
    private Transform player;
    private Vector2 target;
    public GameObject playerHurtEffect;

    // Start is called before the first frame update
    void Start()
    {
        bulletCol = GetComponent<Collider2D>();
        enemyCol = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(enemyCol, bulletCol);

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject hurteffect = Instantiate(playerHurtEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(hurteffect, 2f);
            FindObjectOfType<AudioManager>().Play("PlayerHurt");

        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }



    }
}
