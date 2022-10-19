using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Camera cam;
    private PlayerScore playerScore;
    
    public Rigidbody2D rb;
    Vector2 playerMove;
    Vector2 mousePos;
    bool effectBool;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScore = this.gameObject.GetComponent<PlayerScore>();
        effectBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 direction = playerMove.normalized;
        Vector2 velocity = direction * speed;
        
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(playerScore.health <= 0)
        {


            while (effectBool)
            {
                FindObjectOfType<AudioManager>().Play("GameOver");
                effectBool = false;
                
            }
        }

     }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
    }
}
