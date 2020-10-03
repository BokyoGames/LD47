using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    public float speed = 1f;
    public int iterations = 10;
    public int max_line_point = 500;
    public bool smooth = true;
    public LineRenderer lineToFollow;
    private Vector3 [] wayPoints;
    private int currentPoint = 0;

    private bool completed = false;

    private int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 [] temp = new Vector3[max_line_point];
        int total = 0;
        if(lineToFollow != null)
        {
             total = lineToFollow.GetPositions(temp);
             wayPoints = new Vector3[total];

             for(int i = 0; i < total; i++)
                 wayPoints[i] = temp[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null)
            return;
        
        if(completed)
        {
            Destroy(gameObject);
            return;
        }
        
        if(0 < wayPoints.Length)
        {
            if(smooth)
                FollowSmooth ();
            //  else {
            //      FollowClumsy ();
            //  }
        }
    }

    private void IncreaseIndex()
    {
        currentPoint++;
        if(currentPoint == wayPoints.Length) 
        {
            completed = true;
            Destroy(gameObject);
        }
    }

    private Vector3 Prevoius(int index)
    {
        if(0 == index) 
            return wayPoints[wayPoints.Length - 1];
        else 
            return wayPoints[index - 1];  
    }

    private Vector3 Current(int index)
    {
        if(index < wayPoints.Length)
            return wayPoints[index];
        
        return wayPoints[0];
    }

    Vector3 Next(int index)
    {
        if(index + 1 >= wayPoints.Length) 
            return wayPoints[wayPoints.Length - 1];
        else 
            return wayPoints[index + 1];
    }

    private void FollowSmooth()
    {
         Vector3 anchor1 = Vector3.Lerp(Prevoius(currentPoint), Current(currentPoint), .5f);
         Vector3 anchor2 = Vector3.Lerp(Current(currentPoint), Next(currentPoint), .5f);
 
         if(i < iterations) 
         {
            float currentProgress = (1f / (float)iterations) * (float)i;
            //  transform.LookAt (Vector3.Lerp (anchor1, Current (currentPoint), currentProgress));
            transform.position = Vector3.Lerp(Vector3.Lerp(anchor1, Current(currentPoint), currentProgress), Vector3.Lerp(Current(currentPoint), anchor2, currentProgress), currentProgress);
            i++;
         }
         else 
         {
            i = 1;
            IncreaseIndex();
            Vector3 absisa = Vector3.Lerp(Vector3.Lerp(anchor1, Current(currentPoint), .5f), Vector3.Lerp(Current(currentPoint), anchor2, .5f), .5f);
            float it = (((anchor1-absisa).magnitude + (anchor2 - absisa).magnitude)/(speed*Time.deltaTime));
            iterations = (int)it;
          }
     }
}
