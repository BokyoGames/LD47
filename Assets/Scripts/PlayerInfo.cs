using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_life_point = 10;
    public int life_point = 10;

    public int music_energy = 0;
    public int total_score = 0;

    private Text ui_energy;
    private Text ui_total_score;

    void Start()
    {
        ui_energy = GameObject.Find("Energy").GetComponent<Text>();
        ui_total_score = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Energy: "+music_energy);
        ui_energy.text = music_energy.ToString();
        ui_total_score.text = total_score.ToString();
    }

    public void AddEnergy(int energy)
    {
        music_energy += energy;
        total_score += energy;
    }
}
