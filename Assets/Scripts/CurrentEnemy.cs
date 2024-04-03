using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy : MonoBehaviour
{
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public Transform defaultTarget;
    private Transform currentTarget;
    private EnemyState currentState;

    public bool unmoving;

    enum EnemyState
    {
        PATROL,
        GOINGBACK,
        CHASE
    }

    //private EnemyState currentState = EnemyState.PATROL;
    public float speed = 5.0f;
    // Start is called before the first frame update

    //player gameobject
    public GameObject player;

    //Radius of the enemy
    public float radius = 5.0f;
    void Start()
    {

        //If patrol points
        if(patrolPoint1 != null && patrolPoint2 != null && defaultTarget != null)
        {
            currentTarget = patrolPoint1;
            currentState = EnemyState.PATROL;
        } else {
            //Dont move
            //Log
            //Debug.Log("No patrol points found");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(unmoving)
        {
            return;
        }
        //State machine
        if(patrolPoint1 != null && patrolPoint2 != null && defaultTarget != null)
        {
            switch (currentState)
            {
                case EnemyState.PATROL:
                    //Log
                    //Debug.Log("Patrolling");
                    MoveTowardsTarget();
                    break;
                case EnemyState.GOINGBACK:
                    //Log
                    //Debug.Log("Going back to patrol");
                    MoveBackToPatrol();
                    break;
                case EnemyState.CHASE:
                    //Log
                    //Debug.Log("Chasing player");
                    MoveTowardsPlayer(); 
                    break;
            }
        } else {
            //Dont move
        }

        TimeSwitchEnemy();
    }

    void MoveTowardsTarget()
    {
        //Log
        //Debug.Log("Moving towards target");

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Check if the enemy has reached the patrol point
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // Switch to the other patrol point
            currentTarget = currentTarget == patrolPoint1 ? patrolPoint2 : patrolPoint1;
        }

        // Check if the player is within the radius
        if (Vector3.Distance(player.transform.position, transform.position) < radius)
        {
            currentState = EnemyState.CHASE;
        }
    }

    void MoveTowardsPlayer()
    {
        //Move towards the player gameobject but if it exceeds the radius, dont move
        if (Vector3.Distance(player.transform.position, transform.position) < radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        } else {
            currentState = EnemyState.GOINGBACK;
        }
    }

    void MoveBackToPatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, defaultTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, defaultTarget.position) < 0.1f)
        {
            currentState = EnemyState.PATROL;
        }
        // Check if the player is within the radius
        if (Vector3.Distance(player.transform.position, transform.position) < radius)
        {
            currentState = EnemyState.CHASE;
        }
    }

    void TimeSwitchEnemy()
    {

    }
}