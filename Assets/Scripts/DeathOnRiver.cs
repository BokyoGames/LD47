using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnRiver : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("River"))
        {
            Die();
        }
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("River"))
        {
            Die();
        }
    }
}
