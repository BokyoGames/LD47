﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    public List<int> prices = new List<int>();
    public List<string> tower_name = new List<string>();
    private List<bool> buyed = new List<bool>();

    private PlayerInfo player_info;

    private bool displayed_tutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        player_info = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        foreach(int price in prices)
            buyed.Add(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<tower_name.Count;i++)
        {
            string name = tower_name[i];
            int price = prices[i];

            
            GameObject tower = GameObject.Find("Shop/" + name);
            if(tower != null)
            {
                AbstractEmitter a = tower.GetComponent<AbstractEmitter>();
                a.price = price;

                DragAndDrop drag_and_drop = tower.GetComponent<DragAndDrop>();
                SpriteRenderer tower_base = GameObject.Find("Shop/" + name + "/Turret_Base").GetComponent<SpriteRenderer>();
                SpriteRenderer tower_cannon = GameObject.Find("Shop/" + name + "/Turret_Cannon").GetComponent<SpriteRenderer>();
                SpriteRenderer tower_top = GameObject.Find("Shop/" + name + "/Turret_Top").GetComponent<SpriteRenderer>();
                SpriteRenderer light = GameObject.Find("Shop/" + name + "/TowerLight").GetComponent<SpriteRenderer>();
                
                if(!buyed[i])
                {
                    // Color dark = Color.black;
                    Color dark = new Color(0.32f, 0.32f, 0.32f, 1f);

                    if(price <= player_info.music_energy)
                    {
                        if(!displayed_tutorial)
                        {
                            TutorialMessage tutorial = GameObject.Find("Tutorial").GetComponent<TutorialMessage>();
                            tutorial.DisplayEnergyMessage();
                            displayed_tutorial = true;
                        }

                        drag_and_drop.disabled = false;
                        tower_base.color = dark;
                        tower_cannon.color = dark;
                        tower_top.color = dark;
                        light.enabled = true;
                    }
                    else
                    {
                        light.enabled = false;
                        drag_and_drop.disabled = true;
                        tower_base.color = dark;
                        tower_cannon.color = dark;
                        tower_top.color = dark;
                    }
                }
                else
                {
                    light.enabled = false;
                    tower_base.color = Color.white;
                    tower_cannon.color = Color.white;
                    tower_top.color = Color.white;
                }

                if(tower.transform.position.x > -6.37)
                {
                    if(!buyed[i])
                    {
                        Debug.Log("Spend money on tower");
                        player_info.music_energy -= price;
                        buyed[i] = true;
                        drag_and_drop.disabled = false;
                        tower_base.color = Color.white;
                        tower_cannon.color = Color.white;
                        tower_top.color = Color.white;
                    }
                }
            }            
        }
    }
}
