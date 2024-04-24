using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOutlineSprite : MonoBehaviour
{

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
  
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a line through the length of the sprite
        Vector3[] linePositions = new Vector3[2];
        
        //Get the sprite bounds
        Bounds bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
        //Get the sprite size
        Vector3 size = bounds.size;
        
        //Get the sprite center based on sprite position
        Vector3 center = bounds.center;

        //Get the sprite rotation
        Vector3 rotation = gameObject.transform.eulerAngles;

        //Get the corners of the sprite
        Vector3 topLeft = new Vector3(center.x - size.x / 2, center.y + size.y / 2, center.z);
        Vector3 topRight = new Vector3(center.x + size.x / 2, center.y + size.y / 2, center.z);
        Vector3 bottomLeft = new Vector3(center.x - size.x / 2, center.y - size.y / 2, center.z);
        Vector3 bottomRight = new Vector3(center.x + size.x / 2, center.y - size.y / 2, center.z);

        
        //Rotate the corners
        topLeft = RotatePointAroundPivot(topLeft, center, rotation);
        topRight = RotatePointAroundPivot(topRight, center, rotation);
        bottomLeft = RotatePointAroundPivot(bottomLeft, center, rotation);
        bottomRight = RotatePointAroundPivot(bottomRight, center, rotation);

        //Set the line positions
        linePositions[0] = topLeft;
        Debug.Log("Top Left: " + topLeft);
        linePositions[1] = topRight;
        Debug.Log("Top Right: " + topRight);

        lineRenderer.SetPositions(linePositions);





    }
}
