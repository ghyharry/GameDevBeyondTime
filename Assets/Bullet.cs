using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        // Destroy the bullet after 5 seconds
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Move the bullet forward
        //transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Print the GameObject's name
        Debug.Log(" BulletCollision detected ");
        Debug.Log(collision.gameObject.name);

        //If the bullet hits an obstacle and is same color, destroy the obstacle
        if (collision.gameObject.CompareTag("Obstacle") )
        {
            //Print the color of the obstacle and the bullet
            Debug.Log("XF" + collision.gameObject.GetComponent<SpriteRenderer>().color.ToString());
            Debug.Log("XF" + GetComponent<SpriteRenderer>().color.ToString());

            if (CheckSameColor(collision.gameObject.GetComponent<SpriteRenderer>().color, GetComponent<SpriteRenderer>().color))
            {
                // Destroy the obstacle
                Debug.Log("XF Destroying obstacle");
                Destroy(collision.gameObject);
            }
            
        }

        

        // Dont destroy the bullet if it hits the player or gun
        // if (collision.gameObject.CompareTag("Player") )
        // {
        //     return;
        // }
        Destroy(gameObject);

        // Optional: Add more logic here if you want to exclude certain objects from causing destruction
        // For example, you might not want the bullet to be destroyed when hitting power-ups
        // if (!collision.gameObject.CompareTag("PowerUp"))
        // {
        //     Destroy(gameObject);
        // }
    }
    
    //Function to check if two colors are the same or very similar
    public bool CheckSameColor(Color color1, Color color2)
    {
        //Check if the colors are within a certain range of each other
        if (Mathf.Abs(color1.r - color2.r) < 0.1f && Mathf.Abs(color1.g - color2.g) < 0.1f && Mathf.Abs(color1.b - color2.b) < 0.1f)
        {
            return true;
        }
        return false;
    }
}
