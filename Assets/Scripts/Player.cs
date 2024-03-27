using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject gameManager;

    public GameManager gameManagerScript;
    public GameObject floor;
    public GameObject restartUI;
    public GameObject platform2;
    public GameObject winUI;
    public GameObject platform;
    public GameObject currentBoss;
    public GameObject pastBoss;
    public GameObject redWall;
    public Material currentFloorMaterial;
    public Material pastFloorMaterial;
    public TMP_Text TimelineTrackerText;
    public TMP_Text GunPickedText;
    private Rigidbody2D rb;

    public float jumpCoefficient = 1f;
    public float speed = 10.0f;
    public float cspeed =0.0f;
    public float pickUpTime = 10f;
    float horizontalMovement;
    float verticalMovement;

    public float bounceBackWaitTime;

    public float bounceBackForce = 10.0f;
    private float bounceBackTimer = 0.0f;
    float textTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        GunPickedText.enabled = false;
        //gameManager = new GameManager();
        gameManagerScript = gameManager.GetComponent<GameManager>();
        this.GetComponent<ShootColor>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*void LateUpdate()
    {
        //Move the player only if bounceBackTimer is 0
        if (bounceBackTimer > 0)
        {
            bounceBackTimer -= Time.deltaTime;
            // if (bounceBackTimer <= 0)
            // {
            //     gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            // }
            horizontalMovement = 0.0f;
        }else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }
        //horizontalMovement = Input.GetAxisRaw("Horizontal");


        verticalMovement = Input.GetAxisRaw("Vertical");
        if (horizontalMovement > 0){
            cspeed= speed  * horizontalMovement;
            transform.Translate(cspeed * Time.deltaTime,0.0f,0.0f);
        }
        else{
            Debug.Log(cspeed);
            if (cspeed>0.0f) {
                cspeed-=0.1f;
                transform.Translate(cspeed * Time.deltaTime,0.0f,0.0f);
            }
        }
            
        transform.Translate(Vector3.up * Time.deltaTime * verticalMovement * speed);

        TimeSwitch();
    }*/

    void LateUpdate()
    {
        //Move the player only if bounceBackTimer is 0
        /*if (bounceBackTimer > 0)
        {
            bounceBackTimer -= Time.deltaTime;
            if (bounceBackTimer <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            horizontalMovement = 0.0f;
        }*/
        /*else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }*/

        horizontalMovement = Input.GetAxisRaw("Horizontal");


        verticalMovement = Input.GetAxisRaw("Vertical");
        if (horizontalMovement > 0)
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalMovement);
        else
            Debug.Log("Cannot go back!");
        transform.Translate(Vector3.up * Time.deltaTime * verticalMovement * speed);


        TimeSwitch();
        if(currentBoss == null)
        {
            Destroy(redWall);
        } else if(pastBoss == null)
        {
            Destroy(currentBoss);
        }
    }

    void TimeSwitch()
    {
        Debug.Log("The player value in bool is " + gameManagerScript.isCurrentTimeLine);

        if (gameManagerScript.isCurrentTimeLine)
        {
            Debug.Log("Inside true. ");
            floor.GetComponent<SpriteRenderer>().material = currentFloorMaterial;
            Camera.main.backgroundColor = Color.blue;
            TimelineTrackerText.SetText("Current Timeline");
        }
        else
        {
            floor.GetComponent<SpriteRenderer>().material = pastFloorMaterial;
            Camera.main.backgroundColor = Color.grey;
            TimelineTrackerText.SetText("Past Timeline");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "DeathZone")
        {
            //Send death loc data to firebase db
            //gameManagerScript.DeathAnalytics(new Vector3(transform.position.x, transform.position.y, transform.position.z));


            //Destroy the player
            gameObject.SetActive(false);
            restartUI.SetActive(true);

            //Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Goal")
        {
            gameObject.SetActive(false);
            winUI.SetActive(true);
            //add end game condition.
        }

        else if (collision.collider.tag == "BounceBack")
        {
            //bounce back functionality
            //gameObject.transform.position = new Vector3(60.0f, -1.2f, 0);
            //bounce player back with a force
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceBackForce * -1, 10.0f), ForceMode2D.Impulse);

            //disable horizontal movement
            speed = 0;
            
            bounceBackTimer = bounceBackWaitTime;


            //set player color to grey
            //gameObject.GetComponent<SpriteRenderer>().color = Color.black;

        }
        else if (collision.collider.tag == "Floor")
        {
            speed = 15.0f;
        }

        else if (collision.collider.tag == "PlatformButton")
        {
            //platform movement functionality
            platform.transform.position = new Vector3(75.16f, platform.transform.position.y - 6.0f, 0);
            speed = 15.0f;

            //Debug.Log("Button collision. ");
        }
        else if(collision.collider.tag == "Platform")
        {
            speed = 15.0f;
        }

        else if (collision.collider.tag == "ObstacleButton")
        {
            //platform movement functionality
            platform2.SetActive(false);

            //Debug.Log("Button collision. ");
        }

        else if(collision.collider.tag == "PickUp")
        {
            GunPickedText.enabled = true;
            Debug.Log("Shooting enabled");
            this.GetComponent<ShootColor>().enabled = true;
            Destroy(collision.collider.gameObject);


            StartCoroutine(PickUpTimer());

            //textTimer -= Time.deltaTime;
            Debug.Log("The timer for picked up text is : " + textTimer);

           /* if (textTimer > 0)
            {
                
            }*/
            /*else if (textTimer <= 0)
            {
                
            }*/
        }
        else if(collision.collider.tag == "PastBoss")
        {
            Destroy(pastBoss);
            Destroy(currentBoss);
        }
        else if(collision.collider.tag == "CurrentBoss")
        {
            Destroy(redWall);
        }

    }

    private IEnumerator PickUpTimer()
    {
        yield return new WaitForSeconds(pickUpTime);
        GunPickedText.enabled = false;
    }

    private void OnDestroy()
    {
        //Sending data to firebase for player loc death.
        gameManagerScript.DeathAnalytics(new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }
}





