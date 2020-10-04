﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    public List<int> prices = new List<int>();
    public List<string> tower_name = new List<string>();

    private PlayerInfo player_info;
    // Start is called before the first frame update
    void Start()
    {
        player_info = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
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
                DragAndDrop drag_and_drop = tower.GetComponent<DragAndDrop>();
                SpriteRenderer tower_base = GameObject.Find("Shop/" + name + "/Turret_Base").GetComponent<SpriteRenderer>();
                SpriteRenderer tower_cannon = GameObject.Find("Shop/" + name + "/Turret_Cannon").GetComponent<SpriteRenderer>();
                SpriteRenderer tower_top = GameObject.Find("Shop/" + name + "/Turret_Top").GetComponent<SpriteRenderer>();
                
                if(price <= player_info.music_energy)
                {
                    drag_and_drop.disabled = false;
                    tower_base.color = Color.white;
                    tower_cannon.color = Color.white;
                    tower_top.color = Color.white;
                }
                else
                {
                    drag_and_drop.disabled = true;
                    tower_base.color = new Color(0, 0, 0, 0.5f); 
                    tower_cannon.color = new Color(0, 0, 0, 0.5f); 
                    tower_top.color = new Color(0, 0, 0, 0.5f); 
                }
            }
            
        }
    }
}
