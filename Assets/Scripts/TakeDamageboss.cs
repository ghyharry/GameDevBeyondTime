using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakeDamageboss : MonoBehaviour
{
    private int hitCount = 0; // Tracks the number of hits

    public int damageMax; // Maximum number of hits before object is destroyed
    
    public float bounceBackForce = 10.0f;
    private float bounceBackTimer = 0.0f;
    public Transform current;
    public Transform past;
    
    public TMP_Text bosstxt;
    public bool isPast = false;
    public int firstFlag = 1;
    public float flyTimer=0.0f;
    private Transform marker; // The player's transform
    void Start()
    {
        
        marker = GameObject.FindGameObjectWithTag("PastBoss").transform; // Find the player's transform

    }
    void Update()
    {
        
        flyTimer -=Time.deltaTime;
        this.transform.position=marker.position;
        if (damageMax-hitCount>0){
            bosstxt.text=("Boss takes "+(damageMax-hitCount).ToString() +" bullets to die!");
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
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Debug.Log("Bullet DAMAGE detectedfrom player");

            //Destroy the bullet
            //Debug.Log("dead????");
            Destroy(collision.gameObject);

            hitCount++; // Increment hit count

            if (hitCount >= damageMax)
            {   
                bosstxt.text=("Congratulation! You win!!!");
                Destroy(gameObject); // Destroy the object
                
                
            }else{
                MoveObjectToOtherTimeLine(gameObject);
            }
            
        }else if (collision.collider.tag == "BounceBack")
        {
            //bounce back functionality
            //gameObject.transform.position = new Vector3(60.0f, -1.2f, 0);
            //bounce player back with a force
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceBackForce * -3, 18.0f), ForceMode2D.Impulse);
            flyTimer=2.0f;
            //disable horizontal movement
            //speed = 0;
            
            //bounceBackTimer = bounceBackWaitTime;


            //set player color to grey
            //gameObject.GetComponent<SpriteRenderer>().color = Color.black;

        }
    }
}
