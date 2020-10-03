using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public float drag_height = -1.0f;
    public float final_drag_height = 0.0f;
    private bool dragging = false;
    private float distance;

    private Vector3 initial_position;

    private GameObject[] activators;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        initial_position = gameObject.transform.position;
        activators = GameObject.FindGameObjectsWithTag("Activator");
        // Debug.Log("Activator"); 
        // Debug.Log(activator.transform.position.x); 
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

        if(!dragging)
            return;

        bool droppable = false;

        foreach(GameObject active in activators)
        {
            if(IsInsideBoxCollider(active.transform.position, gameObject.transform.position))
                droppable = true;
        }

        if(droppable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = final_drag_height;
            transform.position = rayPoint;
            initial_position = rayPoint;
            dragging = false;
            droppable = false;
        }
        else
        {
            transform.position = initial_position;
            dragging = false;
            droppable = false;
        }
    }
 
    void Update()
    {
        if (dragging)
        {
            // Debug.Log("Dragging mama!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = drag_height;
            transform.position = rayPoint;
        }
    }

    public static bool IsInsideBoxCollider(Vector3 collider, Vector3 point)
    {
        return Vector3.Distance(collider, point) < 1f;
    }
}
