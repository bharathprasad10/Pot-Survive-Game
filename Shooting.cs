using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletEffect;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Shoot");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            GameObject effect = Instantiate(bulletEffect, transform.position, Quaternion.identity) as GameObject;
            //FindObjectOfType<AudioManager>().Play("Shooting");
            Destroy(effect, 2f);
        }
    }
}
