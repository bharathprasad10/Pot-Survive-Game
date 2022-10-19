using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  
    private Vector2 screenBound;
    public float startTimeBtwnEnemy;
    public PlayerScore playerScore;
    public float minusTime;
    private float minTime = .5f;


    public GameObject enemy;
    float timeBtwnEnemy;
    private Vector2[] randomEnemyPos = new Vector2[4]; // write the ousite position for spawning

    private void Awake()
    {
        float xScreen = Screen.width;
        float yScreen = Screen.height;
        float zScreen = Camera.main.transform.position.z;
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(xScreen, yScreen, zScreen));
    }

    // Start is called before the first frame update
    void Start()
    {
       
      float xRange = screenBound.x;
      float yRange = screenBound.y;
      
      randomEnemyPos[0] = new Vector2(Random.Range(-xRange, xRange), yRange);
      randomEnemyPos[1] = new Vector2(xRange, Random.Range(-yRange, yRange));
      randomEnemyPos[2] = new Vector2(Random.Range(-xRange, xRange), -yRange);
      randomEnemyPos[3] = new Vector2(-xRange, Random.Range(-yRange, yRange));

      //enemy = GameObject.FindGameObjectWithTag("Enemy");

    }

    

    // Update is called once per frame
    void Update()
    {

        SpawnEnemy();
        if (playerScore.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        if (timeBtwnEnemy <= 0f)
        {
            float xRange = screenBound.x;
            float yRange = screenBound.y;

            randomEnemyPos[0] = new Vector2(Random.Range(-xRange, xRange), yRange);
            randomEnemyPos[1] = new Vector2(xRange, Random.Range(-yRange, yRange));
            randomEnemyPos[2] = new Vector2(Random.Range(-xRange, xRange), -yRange);
            randomEnemyPos[3] = new Vector2(-xRange, Random.Range(-yRange, yRange));

            int rand = Random.Range(0, 3);

            GameObject obj = Instantiate(enemy) as GameObject;
            obj.transform.position = randomEnemyPos[rand];
            
            timeBtwnEnemy = startTimeBtwnEnemy;
            if(startTimeBtwnEnemy > minTime)
            {
                startTimeBtwnEnemy -= minusTime;
            }
            
            
        }
        else
        {
            timeBtwnEnemy -= Time.deltaTime;
        }
    }
}
