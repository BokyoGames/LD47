using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOnClick : MonoBehaviour
{
    public int loot_value = 100;
    private PlayerInfo player_info;

    // Start is called before the first frame update
    void Start()
    {
        player_info = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseEnter()
    {
        player_info.AddEnergy(loot_value);
        Destroy(gameObject);
    }

}
