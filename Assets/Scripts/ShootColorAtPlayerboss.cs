using UnityEngine;

public class ShootColorAtPlayerboss : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to shoot
    public GameObject shootingEnemy;
    //GameObject[] bulletArray;
    private Transform player; // The player's transform
    public float shootInterval = 2f; // Time between shots
    public float bulletSpeed = 5f; // Speed of the bullet
    
    private float shootTimer; // Timer to track shooting intervals
    public Vector3 shootOffset = new Vector3(2f, 0, 0);
    void Start()
    {
        shootTimer = shootInterval; // Initialize the shoot timer
        shootingEnemy = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform

    }

    void Update()
    {
        shootTimer -= Time.deltaTime; // Decrease the timer by the time passed since last frame
        
        if (shootTimer <= 0 && player != null)
        {
            ShootAtPlayer(); // Shoot a bullet at the player
            shootTimer = shootInterval; // Reset the timer
        }
        
    }

    void ShootAtPlayer()
    {
        if (bulletPrefab != null)
        {
            // Instantiate the bullet at the position and rotation of the GameObject
            GameObject bullet = Instantiate(bulletPrefab, transform.position + shootOffset, Quaternion.identity);

            // Get the SpriteRenderer of the current GameObject
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Check if the SpriteRenderer component was found
            if (spriteRenderer != null)
            {
                // Set the bullet's color to match the GameObject's SpriteRenderer color
                bullet.GetComponent<SpriteRenderer>().color = spriteRenderer.material.color;

                Debug.Log("Bullet color: " + bullet.GetComponent<SpriteRenderer>().color);
            } else {
                Debug.LogError("SpriteRenderer component not found on this GameObject.");
            }

            // Assuming the bullet moves along the x-axis; modify as needed
            Vector2 shootDirection = transform.right;
            bullet.GetComponent<Bullet>().savedDirection = shootDirection;
            bullet.GetComponent<Bullet>().speed = bulletSpeed;
            bullet.GetComponent<Bullet>().UpdateVelocity();
            
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }
    // private void OnEnable()
    // {
    //     //ShootAtPlayer();
    //     Vector2 direction = (player.position - transform.position).normalized; // Calculate the direction to the player
    //     for (int i = 0; i < bulletArray.Length; i++)
    //     {
    //         bulletArray[i].GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //     }
    //     /*shootTimer = 0; // Decrease the timer by the time passed since last frame

    //     if (shootTimer <= 0 && player != null)
    //     {
    //         ShootAtPlayer(); // Shoot a bullet at the player
    //         shootTimer = shootInterval; // Reset the timer
    //     }*/
    // }
}
