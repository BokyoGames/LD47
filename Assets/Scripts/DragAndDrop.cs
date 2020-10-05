using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public bool disabled = false;
    public float drag_height = -1.0f;
    public float final_drag_height = 0.0f;
    private bool dragging = false;
    private float distance;

    private Vector3 initial_position;

    private GameObject[] activators;
    private AudioSource sound;

    AbstractEmitter abstract_emitter;
    Text ui_description;
    CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        ui_description = GameObject.Find("TowerName").GetComponent<Text>();
        canvas = GameObject.Find("TowerName").GetComponent<CanvasGroup>();
        Cursor.visible = true;
        initial_position = gameObject.transform.position;
        activators = GameObject.FindGameObjectsWithTag("Activator");
        sound = GameObject.Find("Shop").GetComponent<AudioSource>();
        abstract_emitter = GetComponent<AbstractEmitter>();
        // Debug.Log("Activator"); 
        // Debug.Log(activator.transform.position.x); 
   }

    void OnMouseDown()
    {
        if(disabled)
            return;

        Debug.Log("Mouse down");
        sound.Play();
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

        foreach(GameObject active in activators)
        {
            if(IsInsideBoxCollider(active.transform.position, gameObject.transform.position))
            {
                active.transform.GetComponent<ActivatorStatus>().occupied = false;
            }
        }
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
                if(!active.transform.GetComponent<ActivatorStatus>().occupied)
                {
                    active.transform.GetComponent<ActivatorStatus>().occupied = true;

                    Vector3 final_position = new Vector3(active.transform.position.x, active.transform.position.y, final_drag_height);
                    transform.position = final_position;
                    initial_position = final_position;
                    dragging = false;
                    droppable = false;
                }
            }

            if(gameObject.transform.position.x < -6.37f)
            {
                Vector3 final_position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, final_drag_height);
                transform.position = final_position;
                initial_position = final_position;
                dragging = false;
                droppable = false;
            }
        }

        if(!droppable)
        {
            foreach(GameObject active in activators)
            {
                if(IsInsideBoxCollider(active.transform.position, initial_position))
                {
                    active.transform.GetComponent<ActivatorStatus>().occupied = true;
                }
            }

            transform.position = initial_position;
            dragging = false;
            droppable = false;
        }
    }

    private void OnMouseEnter() 
    {
        ui_description.text = abstract_emitter.tower_name+"     "+abstract_emitter.price+"\n<i>"+abstract_emitter.tower_description+"</i>";
        canvas.alpha = 1f;
    }

    private void OnMouseExit() 
    {
        canvas.alpha = 0f;
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
