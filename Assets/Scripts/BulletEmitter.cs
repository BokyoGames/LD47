using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

        if(this.gameObject.transform.position.x < -5.7)
        {
            // Debug.Log("Out position");
            passed_period = Time.time;

            emitter_enabled = false;
            return;
        }
        else
            emitter_enabled = true;

        if(Time.time > passed_period) 
        {
            passed_period += period;
            
            if(ryhme == 0)
            {
                tower_beat.Stop();
                Debug.Log("Play audio");
                tower_beat.Play();
            }

            ryhme = (ryhme + 1) % spawn_track_vector.Length;
            if(spawn_track_vector[ryhme] != 0)
            {    
                Rigidbody2D instance = Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation) as Rigidbody2D;
                Vector3 force_forward = this.gameObject.transform.TransformDirection(Vector3.right);
                instance.AddForce(force_forward*power);
            }
            
        }

    }
}
