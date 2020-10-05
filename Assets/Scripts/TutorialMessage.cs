using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessage : MonoBehaviour
{
    private string[] message = {
        "“General Thunderer, it is truly an honor to serve under your command in this epic battle. My name is Colonel Fuzzian Whaer and I am your Assigned Tactical Assistant.”",
        "“Every turret we possess is automated and has a different firing pattern. You can see the rhythm of all active turrets clearly in the track below the battlefield.”",
        "“Sir, our enemies are attacking! If one of them reaches our base, they will damage it. You can see our structure integrity next to the firing pattern track. We can’t let it drop to 0!”",
        "“General, our enemies are dropping 8Beats on the ground as they fall. I wonder how they got hold of our local currency… Anyway, you can collect it from the battlefield using your cursor!”",
        "“You have now collected enough 8Beats to buy and activate another turret. Choose one you like from the reserves, then drag it into position and let it wreak havoc on the invasors!”",
        "“You can always decide to replace an active turret by dragging it to another free slot (or back to the reserves) and placing another one in its previously occupied slot.”",
        "“I will now let you lead our defenses by yourself. I will come to speak to you again if we receive any relevant information regarding our enemies. For Shakeassion VII!”",
        "“Sir, our spotters reported that the humans are deploying stronger units! These Tanks, as they call them, are much more resilient than their regular infantry troops: be ready!”",
        "“General Thunderer, our enemies will soon be starting an aerial attack against our base! Our low frequency sound waves are completely ineffective against flying units... and, as if this wasn’t enough, they seem to be able to dodge our Lasers as well!”"
    };

    private float[] timer = {0, 8, 16, 24, 72, 120};
    private float[] timer_energy = {8, 16};

    private int mex_index = 0; 

    private Text ui_tutorial;

    private CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        ui_tutorial = GetComponent<Text>();
        canvas = GetComponent<CanvasGroup>();
        
        for(int i=0; i<timer.Length; i++)
            Invoke("DisplayMessage", timer[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayMessage()
    {
        ui_tutorial.enabled = true;
        canvas.alpha = 1f;
        ui_tutorial.text = message[mex_index];
        mex_index++;
        Invoke("HideMessage", 7.5f);
    }

    void HideMessage()
    {
        ui_tutorial.enabled = false;
        canvas.alpha = 0f;
    }

    public void DisplayEnergyMessage()
    {
        mex_index = 4;
        DisplayMessage();

        for(int i=0; i < timer_energy.Length; i++)
            Invoke("DisplayMessage", timer_energy[i]);
    }
}
