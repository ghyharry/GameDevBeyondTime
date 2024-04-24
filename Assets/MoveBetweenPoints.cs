using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;

    private int nextPoint;

    public bool moveOnlyOnCommand = false;

    private bool commandOnlyMoved = false;

    public int moveSpeed = 5;

    //Keep -1 to move indefinitely
    public int maxMoveCount = -1;

    void Start()
    {
        MoveToPoint(points[0]);
        nextPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(points.Length < 2 || maxMoveCount == 0)
        {
            return;
        }
        if(moveOnlyOnCommand)
        {
            if(!commandOnlyMoved)
            {
                return;
            } else {
                MoveTowardsPoint(points[nextPoint]);
                if(Vector3.Distance(transform.position, points[nextPoint].position) < 0.1f)
                {
                    commandOnlyMoved = false;
                    SetNextPoint();
                    if(maxMoveCount > 0)
                    {
                        maxMoveCount--;
                    }
                }
            }
        } else {
            MoveTowardsPoint(points[nextPoint]);
            if(Vector3.Distance(transform.position, points[nextPoint].position) < 0.1f)
            {
                SetNextPoint();
                if(maxMoveCount > 0)
                {
                    maxMoveCount--;
                }
            }
        }
    }

    private void SetNextPoint()
    {
        if(nextPoint < points.Length - 1)
        {
            nextPoint++;
        } else {
            nextPoint = 0;
        }
    }

    public void MoveToPoint(Transform point)
    {
        if(point != null)
        {
            transform.position = point.position;
        }
    }

    public void MoveTowardsPoint(Transform point)
    {
        if(point != null)
        {
            //Move towards point 1 using deltaTime
            transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        }
    }

    public void CommandMoveToNextPoint()
    {
        commandOnlyMoved = true;
        Debug.Log("Commanded to move to next point");
    }


}
