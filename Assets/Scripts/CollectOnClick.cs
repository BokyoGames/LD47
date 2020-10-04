using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOnClick : MonoBehaviour
{
    public int loot_value = 10;
    public float loot_lifespan = 8;
    private PlayerInfo player_info;

    // Start is called before the first frame update
    void Start()
    {
        player_info = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        Invoke("Disappear", loot_lifespan);
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

    void Disappear()
    {
        Destroy(gameObject);
    }
}
