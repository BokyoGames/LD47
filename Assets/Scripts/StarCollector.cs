using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollector : AbstractEmitter
{
    public float collector_force = 1;
    private PlayerInfo player_info;
    // Start is called before the first frame update
    void Start()
    {
        player_info = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        tower_beat = GetComponent<AudioSource>();
        tower_cannon = transform.Find("Turret_Cannon").gameObject;
        period = 4f/spawn_track_vector.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < shoop_out_position || this.gameObject.transform.position.z != 0)
        {
            MusicStatic.DisableTrack(tower_id);
            emitter_enabled = false;
            return;
        }
        else
        {
            MusicStatic.EnableTrack(tower_id);
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
            // Vector3 force_forward = this.gameObject.transform.TransformDirection(this.gameObject.transform.position);
            // drop.GetComponent<Rigidbody2D>().AddForce(force_forward * collector_force);
            Vector3 direction = drop.transform.position - transform.position;
            drop.GetComponent<Rigidbody2D>().AddForce(-collector_force * direction);
            // drop.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * collector_force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Drop"))
        {
            CollectOnClick drop = collision.gameObject.GetComponent<CollectOnClick>();
            player_info.AddEnergy(drop.loot_value);
            Destroy(collision.gameObject);
        }
    }
}
