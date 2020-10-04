using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    public GameObject loot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropLoot()
    {
        GameObject instance = Instantiate(loot, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
    }
}
