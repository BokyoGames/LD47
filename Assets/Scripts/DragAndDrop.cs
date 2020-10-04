using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool disabled = false;
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
        if(disabled)
            return;

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

        // TODO: Move this during dragging to enable activator color and etc...
        foreach(GameObject active in activators)
        {
            if(IsInsideBoxCollider(active.transform.position, gameObject.transform.position))
            {
                Vector3 final_position = new Vector3(active.transform.position.x, active.transform.position.y, final_drag_height);
                transform.position = final_position;
                initial_position = final_position;
                dragging = false;
                droppable = false;
            }
        }

        if(!droppable)
        {
            transform.position = initial_position;
            dragging = false;
            droppable = false;
        }
    }
 
    void Update()
    {
        if(disabled)
            return;

        if(dragging)
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
        Vector3 tmp_collider = collider;
        tmp_collider.z = point.z;
        return Vector3.Distance(tmp_collider, point) < 1f;
    }
}
