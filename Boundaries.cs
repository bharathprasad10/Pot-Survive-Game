using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Vector2 screenBound;
    private Vector3 viewPos;

    
    float playerWidth;
    float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        

        playerWidth = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;


    }

    private void Awake()
    {
        float xScreen = Screen.width;
        float yScreen = Screen.height;
        float zScreen = Camera.main.transform.position.z;
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(xScreen, yScreen, zScreen));
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBound.x * -1 + playerWidth, screenBound.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBound.y * -1 + playerHeight, screenBound.y - playerHeight);
        transform.position = viewPos;

       
    }
}
