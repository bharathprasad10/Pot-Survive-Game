using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip enemyDeath1, enemyDeath2, enemyDeath3;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeath1 = Resources.Load<AudioClip>("EnemyDeath1");
        enemyDeath2 = Resources.Load<AudioClip>("EnemyDeath2");
        enemyDeath3 = Resources.Load<AudioClip>("EnemyDeath3");

        audioSource = GetComponent<AudioSource>();
    }

   public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "EnemyDeath1": 
                audioSource.PlayOneShot(enemyDeath1);
                break;

            case "EnemyDeath2":
                audioSource.PlayOneShot(enemyDeath2);
                break;

            case "EnemyDeath3":
                audioSource.PlayOneShot(enemyDeath3);
                break;
        }
    }
}
