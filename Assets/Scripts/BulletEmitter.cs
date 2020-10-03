using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Reflection;

public class BulletEmitter : MonoBehaviour
{
    public AudioSource tower_beat;
    public Rigidbody2D bullet;
    public List<Vector3> tower_shoot_direction = new List<Vector3>();

    public BulletBehaviour bullet_behaviour;
    public float power = 500f;

    public int[] spawn_track_vector = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    public bool emitter_enabled = true;

    public float shopt_out_position = -6.37f;
    private GameObject tower_cannon;
    private float angle = 0.0f;

    private float period = 4f/32;

    private Vector3 tower_direction = Vector3.right;
    private int shot_at = 0;

    // Start is called before the first frame update
    void Start()
    {
        tower_beat = GetComponent<AudioSource>();
        bullet_behaviour = GetComponent<BulletBehaviour>();
        tower_cannon = transform.Find("Turret_Kicker_Cannon").gameObject;
        period = 4f/spawn_track_vector.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < shopt_out_position || this.gameObject.transform.position.z != 0)
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
                        Invoke("SpawnBullet", i*period);
                }
            }
        }       
    }

    private void SpawnBullet()
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
        Vector3 force_forward = this.gameObject.transform.TransformDirection(tower_direction);
        instance.AddForce(force_forward * power);
        bullet_behaviour.AddBulletLogic(instance, tower_direction, power, angle);
    }
}
