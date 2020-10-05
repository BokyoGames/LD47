using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaveBehaviour : MonoBehaviour
{
    private Vector3 bullet_scale = new Vector3(0.6f, 0.6f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += bullet_scale * Time.deltaTime;   
    }
}
