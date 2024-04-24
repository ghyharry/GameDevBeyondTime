using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineBetweenChildren : MonoBehaviour
{
    // Start is called before the first frame update
    public bool drawLineBackToStart = false;

    void Start()
    {
        //Get all the children of the gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //If there are no children
        if(children.Length < 2)
        {
            //Log
            Debug.Log("Not enough children to draw line");
            return;
        } else {
            //Log
            Debug.Log("Drawing line between children, number of children: " + children.Length);
        }
        //Get the line renderer component
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //Set the number of points to the number of children

        if( drawLineBackToStart)
        {
            lineRenderer.positionCount = children.Length;
            //Set the positions of the line renderer to the positions of the children
            for(int i = 1; i < children.Length; i++)
            {
                lineRenderer.SetPosition(i-1, children[i].position);
            }

            //Set the last position to the first position
            lineRenderer.SetPosition(children.Length-1, children[1].position);

        } else {
            lineRenderer.positionCount = children.Length-1;
            //Set the positions of the line renderer to the positions of the children
            for(int i = 1; i < children.Length; i++)
            {
                lineRenderer.SetPosition(i-1, children[i].position);
            }
        }
        

        //If the line should be drawn back to the start
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
