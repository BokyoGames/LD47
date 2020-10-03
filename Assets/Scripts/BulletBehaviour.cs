using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBulletLogic(Rigidbody2D instance, Vector3 direction, float power)
    {
        Vector3 force_forward = this.gameObject.transform.TransformDirection(direction);
        instance.AddForce(force_forward * power);
    }
}
