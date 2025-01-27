using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private int hitCount = 0; // Tracks the number of hits

    public int damageMax; // Maximum number of hits before object is destroyed
    public int damageWeak; // Number of hits before object enters weak state

    public Transform current;
    public Transform past;
    
    public GameObject restartUI;
    public bool isPast = false;
    public int firstFlag = 1;

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
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Debug.Log("Bullet DAMAGE detected");

            //Destroy the bullet
            Destroy(collision.gameObject);

            hitCount++; // Increment hit count

            // Check if hit count is equal to 3
            if (hitCount == damageWeak)
            {
                Debug.Log("In weak state");
                //if the object tag is "Enemy", set the tag to "EnemyWeak"
                if (gameObject.CompareTag("Enemy"))
                {
                    gameObject.tag = "EnemyWeak";
                }
                
                // Get current objects Halo component
                Behaviour halo = (Behaviour)GetComponent("Halo");
                
                //If it has a halo component
                if (halo != null)
                {
                    //Change halo size to 5
                    halo.enabled = false;
                }
                

            }
            // Check if hit count is equal to or exceeds 5
            else if (hitCount >= damageMax)
            {
                MoveObjectToOtherTimeLine(gameObject); // Destroy the object
                
                //If the object is the player, display the restart UI
                if (gameObject.CompareTag("Player"))
                {
                    restartUI.SetActive(true);
                }
            }
        }
    }
}
