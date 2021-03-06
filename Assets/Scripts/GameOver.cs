﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string base_url = "https://home.512b.it/8beats/";
    AudioSource[] menu_theme;
    Text final_score;
    // Start is called before the first frame update
    void Start()
    {
        menu_theme = GetComponents<AudioSource>();
        menu_theme[1].PlayDelayed(8f);
        final_score = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        final_score.text = "Final score: "+PlayerStatic.total_score;
        if(Input.GetKey("escape"))
        {
            Debug.Log ("Close the app [esc]");
            Application.Quit();
        }
    }
    
    public void QuitGame()
    {
        // Debug.Log ("Close the app");
        // Application.Quit();
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void DownloadTrack()
    {
        Debug.Log(MusicStatic.ToDashString());
        Application.OpenURL(base_url+"mix.php?track="+MusicStatic.ToDashString());
    }
}
