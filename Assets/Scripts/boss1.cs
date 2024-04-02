using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    public GameObject player;

    public float speed = 10.0f;
    public float attackTimerSeconds = 1f;
    public float restTimerSeconds = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pposi= player.transform.position;
        //Debug.Log(pposi);
        AttackPlayer();
    }
    private void AttackPlayer()
    {
        if(player.transform.position.y <= 5.0f)
        {
            StartCoroutine(AttackTimer1());
            StartCoroutine(AttackTimer2());



            /*attackTimerSeconds -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            if (attackTimerSeconds <= 0 && player != null)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                restTimerSeconds -= Time.deltaTime;
                if (restTimerSeconds <= 0 && player != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                    restTimerSeconds = 2f;
                    attackTimerSeconds = 1f;
                }
            }*/
        }
    }

    private IEnumerator AttackTimer1()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        Debug.Log("Started movement. ");
        yield return new WaitForSeconds(1f);
        Debug.Log("Ended movement. ");
        speed = 0;
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

    }
    private IEnumerator AttackTimer2()
    {
        speed = 10f;
        Debug.Log("Waiting for 2 secs.");
        yield return new WaitForSeconds(2f);
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}

