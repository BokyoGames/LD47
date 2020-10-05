using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Reflection;

public class BulletEmitter : AbstractEmitter
{
    public Rigidbody2D bullet;
    public BulletBehaviour bullet_behaviour;
    public float power = 500f;
    public float linear_scale = 0;
    private Vector3 bullet_scale;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10, true);
        Physics2D.IgnoreLayerCollision(14, 10, true);
        Physics2D.IgnoreLayerCollision(9, 14, true);
        tower_beat = GetComponent<AudioSource>();
        bullet_behaviour = GetComponent<BulletBehaviour>();
        tower_cannon = transform.Find("Turret_Cannon").gameObject;
        period = 4f/spawn_track_vector.Length;
        bullet_scale = new Vector3(linear_scale,linear_scale, 0);
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
                        Invoke("SpawnBullet", i*period);
                }
            }
        }       
    }

    public override void SpawnBullet()
    {
        tower_direction = tower_shoot_direction[shot_at];
        shot_at = (shot_at + 1) % tower_shoot_direction.Count;

        float new_angle = Mathf.Atan2(tower_direction.y, tower_direction.x) * Mathf.Rad2Deg;
        
        if(new_angle != angle)
        {
            angle = -angle + new_angle;
            tower_cannon.transform.Rotate(0.0f, 0.0f, angle, Space.World);
            angle = new_angle;
        }

        Rigidbody2D instance = Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation) as Rigidbody2D;
        instance.transform.localScale += bullet_scale;
        Vector3 force_forward = this.gameObject.transform.TransformDirection(tower_direction);
        instance.AddForce(force_forward * power);
        bullet_behaviour.AddBulletLogic(instance, tower_direction, power, angle);
    }
}
