using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportEnemyOnDamage : MonoBehaviour
{
    public Transform current;
    public Transform past;
    public GameObject currentMarker;
    public GameObject pastMarker;
    public GameObject restartUI;
    public TMP_Text timeFlipText;
    public bool isPast = false;
    public int firstFlag = 1;

    private void Start()
    {
        if(timeFlipText != null){
            timeFlipText.enabled = false;
        }
        //timeFlipText.enabled = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Debug.Log("Bullet DAMAGE detected");
            MoveObjectToOtherTimeLine(gameObject);
            //Destroy the bullet
            //Destroy(collision.gameObject);
            if (firstFlag == 1)
            {
                StartCoroutine(Timer());
            }
            firstFlag += 1;

        }



        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            restartUI.SetActive(true);
        }
        
    }
    private IEnumerator Timer()
    {
        timeFlipText.enabled = true;
        yield return new WaitForSeconds(3f);
        timeFlipText.enabled = false;
    }

    public void MoveObjectToOtherTimeLine(GameObject objectToMove)
    {
        // Check if the current timeline is 'Past'
        // string currTimeLine = objectToMove.transform.parent.ToString();
        // string altTimeLine = (currTimeLine == "Past") ? "Current" : "Past"; 
        // GameObject pastGameObject = FindTimeLineObject(altTimeLine);
        Transform pastGameObject = isPast ? current : past;
        isPast = !isPast;
        if (isPast)  //if enemy is in the past timeline.
        {
            //timeFlipText.enabled = false;
            currentMarker.SetActive(true);
            
            pastMarker.SetActive(false);
        }
        else    //if enemy is in the current timeline.
        {
            pastMarker.SetActive(true);
            currentMarker.SetActive(false);
        }

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
