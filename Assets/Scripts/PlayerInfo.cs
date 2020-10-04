using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_life_point = 10;
    public int life_point = 10;

    public int music_energy = 0;
    public int max_music_energy = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Energy: "+music_energy);
    }

    public void AddEnergy(int energy)
    {
        music_energy += energy;
        max_music_energy += energy;
    }
}
