using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_life_point = 10;
    public int life_point = 10;

    public int music_energy = 0;
    public int total_score = 0;

    private Text ui_energy;
    private Text ui_total_score;

    private List<Image> health_bar = new List<Image>();
    void Start()
    {
        ui_energy = GameObject.Find("Energy").GetComponent<Text>();
        ui_total_score = GameObject.Find("Score").GetComponent<Text>();
        
        for(int i = 0; i<max_life_point; i++)
            health_bar.Add(GameObject.Find("Life_" + i).GetComponent<Image>());
    }

    // Update is called once per frame
    void Update()
    {
        ui_energy.text = music_energy.ToString();
        ui_total_score.text = total_score.ToString();

        for(int i = 0; i < max_life_point; i++)
        {
            if(i >= life_point)
                health_bar[i].color = Color.black;
        }

        if(life_point < 0)
        {
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
        }
    }

    public void AddEnergy(int energy)
    {
        music_energy += energy;
        total_score += energy;
    }
}
