using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy : MonoBehaviour
{
    //this is a test comment line
    float horizontalMovement;
    public float speed = 5.0f;
    // Start is called before the first frame update

    //player gameobject
    public GameObject player;

    //Radius of the enemy
    public float radius = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        //Move towards the player gameobject but if it exceeds the radius, dont move
        if (Vector3.Distance(player.transform.position, transform.position) < radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        //transform.Translate(Vector3.left * Time.deltaTime * speed);
        TimeSwitchEnemy();
    }

    void TimeSwitchEnemy()
    {

    }
}
