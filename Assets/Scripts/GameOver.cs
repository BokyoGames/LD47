using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    AudioSource[] menu_theme;
    // Start is called before the first frame update
    void Start()
    {
        menu_theme = GetComponents<AudioSource>();
        menu_theme[1].PlayDelayed(8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Debug.Log ("Close the app [esc]");
            Application.Quit();
        }
    }
    public void QuitGame()
    {
        Debug.Log ("Close the app");
        Application.Quit();
    }
}
