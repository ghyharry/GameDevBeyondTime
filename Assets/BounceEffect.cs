using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to make wall bounce effect when player hits the wall

public class BounceEffect : MonoBehaviour
{
    public float bounceBackWarpAmount = 5f;
    public float bounceBackTimeLimit = 0.8f;

    private float bounceBackTimer = 0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceBackTimer > 0)
        {
            bounceBackTimer -= Time.deltaTime;
            if(bounceBackTimer <= 0)
            {
                //warp object back to original position
                Vector3 warp = gameObject.transform.position;
                warp.x += bounceBackWarpAmount;
                gameObject.transform.position = warp;
                bounceBackTimer = 0.0f;
            }
        }
        //Log position of the object
        Debug.Log("XF "+gameObject.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Add visual bounce effect
            Vector3 warp = gameObject.transform.position;
            warp.x -= bounceBackWarpAmount;
            gameObject.transform.position = warp;

            //Add force to the player
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-collision.gameObject.GetComponent<Player>().bounceBackForce, 0.0f), ForceMode2D.Impulse);

            //Set the bounceBackTimer
            bounceBackTimer = bounceBackTimeLimit;
        }
    }
}
