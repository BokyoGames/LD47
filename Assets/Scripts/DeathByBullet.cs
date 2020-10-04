using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByBullet : MonoBehaviour
{
    public int max_life_point = 1;
    public bool ignore_laser = false;
    public bool ignore_wave = false;
    public bool ignore_bullet = false;
    private int life_point = 1;

    DropOnDeath drop;

    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<DropOnDeath>();
        life_point = max_life_point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        life_point--;
        if(life_point <= 0)
        {
            if(drop)
                drop.DropLoot();

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!ignore_bullet && collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Die();
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision) 
    // {
    //     if(collision.gameObject.CompareTag("Laser"))
    //     {
    //         Die();
    //     }
    // }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(!ignore_laser && collision.gameObject.CompareTag("Laser"))
        {
            Die();
        }

        if(!ignore_wave && collision.gameObject.CompareTag("Wave"))
        {
            Die();
        }
    }
}
