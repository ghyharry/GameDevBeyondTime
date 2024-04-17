using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMarker : MonoBehaviour
{
    public float bounceBackForce = 10.0f;
    
    public float flyTimer=0.0f;
    public float switchTimer=0.0f;
    public GameObject currentBoss;
    private Transform player; 

    public Transform current;
    public Transform past;
    
    
    public bool isPast = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    // Update is called once per frame
    void Update()
    {
        flyTimer -=Time.deltaTime;
        
        if (player.position.y>transform.position.y || transform.position.x>57.0f){
            transform.Translate(Vector3.up * Time.deltaTime * 12.0f );
        }
        if (player.position.x<transform.position.x && flyTimer<=0.0f){
            transform.Translate(Vector3.right  * Time.deltaTime * 12.0f);
        }else{
            transform.Translate(Vector3.right  * Time.deltaTime * 5.0f);
        }
        if (player.position.x>transform.position.x&& currentBoss.active==false){
            switchTimer+=Time.deltaTime;
            if (switchTimer>1.5f){
                MoveObjectToOtherTimeLine(currentBoss);
                switchTimer=0.0f;
            }
            
        }
        if(currentBoss==null)
        {
            Destroy(gameObject);
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

        if (collision.collider.tag == "BounceBack")
        {
            //bounce back functionality
            //gameObject.transform.position = new Vector3(60.0f, -1.2f, 0);
            //bounce player back with a force
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceBackForce * -3, 18.0f), ForceMode2D.Impulse);
            flyTimer=1.5f;
            //disable horizontal movement
            //speed = 0;
            
            //bounceBackTimer = bounceBackWaitTime;


            //set player color to grey
            //gameObject.GetComponent<SpriteRenderer>().color = Color.black;

        }
    }
}
