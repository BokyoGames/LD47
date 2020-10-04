using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollector : AbstractEmitter
{
    public float collector_force = 1;
    // Start is called before the first frame update
    void Start()
    {
        tower_beat = GetComponent<AudioSource>();
        tower_cannon = transform.Find("Turret_Cannon").gameObject;
        period = 4f/spawn_track_vector.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < shoop_out_position || this.gameObject.transform.position.z != 0)
        {
            emitter_enabled = false;
            return;
        }
        else
        {
            emitter_enabled = true;
        }

        if(emitter_enabled)
        {
            float long_ryhme = Time.time % 4f;
        
            if(long_ryhme < Time.deltaTime)
            {
                tower_beat.Stop();
                tower_beat.Play();
                for(int i = 0; i < spawn_track_vector.Length; i++)
                {
                    if(spawn_track_vector[i] != 0)
                        Invoke("SpawnBullet", i * period);
                }
            }
        }  
    }

    public override void SpawnBullet()
    {
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Drop");
        foreach(GameObject drop in drops)
        {
            Vector3 force_forward = this.gameObject.transform.TransformDirection(this.gameObject.transform.position);
            drop.GetComponent<Rigidbody2D>().AddForce(force_forward * collector_force);
        }
    }
}
