using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemyOnDamage : MonoBehaviour
{
    public Transform current;
    public Transform past;
    public bool isPast = false;

    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet DAMAGE detected");

            //Destroy the bullet
            //Destroy(collision.gameObject);
            MoveObjectToOtherTimeLine(gameObject);
        }
    }

    public void MoveObjectToOtherTimeLine(GameObject objectToMove)
    {
        // Check if the current timeline is 'Past'
        // string currTimeLine = objectToMove.transform.parent.ToString();
        // string altTimeLine = (currTimeLine == "Past") ? "Current" : "Past"; 
        // GameObject pastGameObject = FindTimeLineObject(altTimeLine);
        Transform pastGameObject = isPast ? current : past;
        isPast = !isPast;

        // Check if the 'Past' GameObject was found
        if(pastGameObject != null)
        {
            // Set the objectToMove's parent to 'Past'
            //objectToMove.transform.SetParent(pastGameObject.transform);
            objectToMove.transform.SetParent(pastGameObject);
        }
        else
        {
            //Debug.LogError(altTimeLine + " GameObject not found in the scene");
        }
    }

    public GameObject FindTimeLineObject(string timeLine)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == timeLine)
            {
                // GameObject was found, but keep in mind it's not active in the scene
                return obj;
            }
        }
        return null;

    }


    

}
