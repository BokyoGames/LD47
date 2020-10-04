using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLoop : MonoBehaviour
{
    public float time_loop = 4f;
    public float speed = 4;
    private Vector3 starting_position;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float long_ryhme = Time.time % time_loop;
           
        if(long_ryhme < Time.deltaTime)
            transform.position = starting_position;
        else
            transform.Translate(+speed*Time.deltaTime, 0, 0);
    }
}
