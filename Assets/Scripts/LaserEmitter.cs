using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : AbstractEmitter
{
    public List<float> tower_shoot_duration = new List<float>();

    public LineRenderer line;
    public Material line_material;
    private EdgeCollider2D edge;


    // Start is called before the first frame update
    void Start()
    {
        tower_beat = GetComponent<AudioSource>();
        tower_cannon = transform.Find("Turret_Cannon").gameObject;
        period = 4f/spawn_track_vector.Length;
        edge = line.GetComponent<EdgeCollider2D>();
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
        tower_direction = tower_shoot_direction[shot_at];
        float expiration = tower_shoot_duration[shot_at];
        shot_at = (shot_at + 1) % tower_shoot_direction.Count;

        float new_angle = Mathf.Atan2(tower_direction.y, tower_direction.x) * Mathf.Rad2Deg;
        
        if(new_angle != angle)
        {
            angle = -angle + new_angle;
            tower_cannon.transform.Rotate(0.0f, 0.0f, angle, Space.World);
            angle = new_angle;
        }

        // line.SetPosition(0, tower_cannon.transform.GetComponent<Renderer>().bounds.center);
        line.SetPosition(1, tower_direction);

        List<Vector2> colliderPoints2 = new List<Vector2>();
        colliderPoints2.Add(line.GetPosition(0));
        colliderPoints2.Add(tower_direction);
        edge.points = colliderPoints2.ToArray();

        line.enabled = true;
        Invoke("DespawnBullet", expiration * period);
    }

    private void DespawnBullet()
    {
        List<Vector2> colliderPoints2 = new List<Vector2>();
        colliderPoints2.Add(line.GetPosition(0));
        colliderPoints2.Add(line.GetPosition(0));
        edge.points = colliderPoints2.ToArray();
        line.enabled = false;
    }
}