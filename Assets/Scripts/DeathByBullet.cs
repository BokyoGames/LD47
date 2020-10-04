using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByBullet : MonoBehaviour
{

    DropOnDeath drop;

    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<DropOnDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        if(drop)
            drop.DropLoot();

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Shoot by laser!");
            Die();
        }
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Shoot by laser!");
            Die();
        }
    }
}
