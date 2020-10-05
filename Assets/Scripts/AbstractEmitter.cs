using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEmitter : MonoBehaviour
{
    public string tower_id = "0";
    public AudioSource tower_beat;
    public List<Vector3> tower_shoot_direction = new List<Vector3>();
    public int[] spawn_track_vector = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    public float shoop_out_position = -6.37f;
    public bool emitter_enabled = true;
    protected Vector3 tower_direction = Vector3.right;
    protected int shot_at = 0;
    protected GameObject tower_cannon;
    protected float angle = 0.0f;
    protected float period = 4f/32;

    public abstract void SpawnBullet();
}




