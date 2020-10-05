using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    AudioSource[] menu_theme;
    // Start is called before the first frame update
    void Start()
    {
        menu_theme = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("Play the game!");
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void PlanetEarthPlay()
    {
        Debug.Log("Play the game!");
        menu_theme[1].Play();
        StartCoroutine(FadeAudioSource.StartFade(menu_theme[0], 2f, 0f));
        Invoke("PlanetEarth", 2f);
    }

    private void PlanetEarth()
    {
        SceneManager.LoadSceneAsync("TutorialScene", LoadSceneMode.Single);
    }
    public void PlanetShakeassionPlay()
    {
        Debug.Log("Play the game!");
        SceneManager.LoadSceneAsync("TutorialScene2", LoadSceneMode.Single);
    }
}
