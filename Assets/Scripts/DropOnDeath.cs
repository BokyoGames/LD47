using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    public Rigidbody2D loot;
    public float fly_speed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropLoot()
    {
        Vector3 min = new Vector3(1,1,0);
        Vector3 max = new Vector3(-1,-1,0);
        Vector3 force_direction = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
        Rigidbody2D instance = Instantiate(loot, this.gameObject.transform.position, this.gameObject.transform.rotation) as Rigidbody2D;
        Vector3 force_forward = this.gameObject.transform.TransformDirection(force_direction);
        instance.AddForce(force_forward * fly_speed);
    }
}
