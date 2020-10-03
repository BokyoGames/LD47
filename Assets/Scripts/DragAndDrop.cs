using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse down");
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        Debug.Log("Mouse up");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        rayPoint.z = 0;
        transform.position = rayPoint;
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Debug.Log("Dragging mama!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = -1;
            transform.position = rayPoint;
        }
    }
}
