using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 savedDirection;
    private float bulletTimeAlive = 5f;
    private bool isActive = false;

    //public GameObject gameManager;

    //[HideInInspector]
    // public GameManager gameManagerScript;




    void Start()
    {
        //gameManagerScript = gameManager.GetComponent<GameManager>();
        // Destroy the bullet after 5 seconds
        //Destroy(gameObject, 5f);
        
    }

    void Update()
    {
        // Move the bullet forward
        //transform.position += transform.right * speed * Time.deltaTime;
        //If bullet is active, decrement time alive, if the time alive is 0, destroy the bullet.
        if (isActive)
        {
            bulletTimeAlive -= Time.deltaTime;
            if (bulletTimeAlive <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnEnable()
    {
        // Set the velocity of the bullet to the saved direction
        GetComponent<Rigidbody2D>().velocity = savedDirection * speed;
        isActive = true;
    }

    //If bullet is disabled, set isActive to false.
    void OnDisable()
    {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Print the GameObject's name
        Debug.Log(" BulletCollision detected ");
        Debug.Log(collision.gameObject.name);



        // Dont destroy the bullet if it hits the player or gun
        // if (collision.gameObject.CompareTag("Player") )
        // {
        //     return;
        // }
        Debug.Log("The player is going to be destroyed. ");
        //gameManagerScript.DeathAnalytics(new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z));

        Destroy(gameObject);

        // Optional: Add more logic here if you want to exclude certain objects from causing destruction
        // For example, you might not want the bullet to be destroyed when hitting power-ups
        // if (!collision.gameObject.CompareTag("PowerUp"))
        // {
        //     Destroy(gameObject);
        // }
    }

}
