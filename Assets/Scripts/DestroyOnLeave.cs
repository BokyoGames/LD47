using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if(!GeometryUtility.TestPlanesAABB(planes , this.gameObject.GetComponent<Collider2D>().bounds))
        {
            // Debug.Log("Destroy me");
            Destroy(gameObject);
        }
    }
}
