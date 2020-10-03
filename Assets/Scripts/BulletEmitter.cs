using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Reflection;

public class BulletEmitter : MonoBehaviour
{
    public AudioSource tower_beat;
    public Rigidbody2D bullet;
    public float power = 500f;

    public int[] spawn_track_vector = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    public bool emitter_enabled = true;

    private float passed_period = 0.0f;
    private int ryhme = 0;

    private float period = 4f/32;


    // Start is called before the first frame update
    void Start()
    {
        tower_beat = GetComponent<AudioSource>();
        period = 4f/spawn_track_vector.Length;
    }

    // Update is called once per frame
    void Update()
    {

        if(this.gameObject.transform.position.x < -5.7 || this.gameObject.transform.position.z != 0)
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
            
            Debug.Log("Long ryme " + long_ryhme);
            if(long_ryhme < Time.deltaTime)
            {
                tower_beat.Stop();
                tower_beat.Play();
                for(int i = 0; i < spawn_track_vector.Length; i++)
                {
                    Debug.Log("Lancio le bombe!");
                    if(spawn_track_vector[i] != 0)
                        Invoke("SpawnBullet", i*period);
                }
            }
        }       
    }

    private void SpawnBullet()
    {
        Rigidbody2D instance = Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation) as Rigidbody2D;
        Vector3 force_forward = this.gameObject.transform.TransformDirection(Vector3.right);
        instance.AddForce(force_forward*power);
    }
}
