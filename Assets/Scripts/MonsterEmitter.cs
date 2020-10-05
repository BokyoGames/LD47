using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEmitter : MonoBehaviour
{
    public Rigidbody2D monster;
    public LineRenderer lineToFollow;
    
    public float period = 4f/32;
    public float spwan_probability = 32;
    public float next_spawn_time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + next_spawn_time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > next_spawn_time) 
        {
            next_spawn_time += period;
            if(Random.Range(0,31) < spwan_probability)
            {
                Rigidbody2D instance = Instantiate(monster, transform.position, transform.rotation) as Rigidbody2D;
                EnemyBaseAI enempy_ai = instance.GetComponent<EnemyBaseAI>();
                enempy_ai.lineToFollow = lineToFollow;
            }
        }
    }
}
