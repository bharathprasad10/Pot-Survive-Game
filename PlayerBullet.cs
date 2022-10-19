using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    
    public float bulletSpeed;
    private Collider2D bulletCol;
    private Collider2D playerCol;
    public GameObject playerBulletEffect;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        bulletCol = GetComponent<Collider2D>();
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerCol, bulletCol);
        FindObjectOfType<AudioManager>().Play("Shooting");

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject effect = Instantiate(playerBulletEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 2f);
        Destroy(gameObject);

       
        
    }
}
