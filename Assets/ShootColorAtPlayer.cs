using UnityEngine;

public class ShootColorAtPlayer : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to shoot
    public Transform player; // The player's transform
    public float shootInterval = 2f; // Time between shots
    public float bulletSpeed = 5f; // Speed of the bullet

    private float shootTimer; // Timer to track shooting intervals

    void Start()
    {
        shootTimer = shootInterval; // Initialize the shoot timer
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
            Vector3 offset = new Vector3(0, 2f, 0); // Offset to spawn the bullet slightly above the shooter
            GameObject bullet = Instantiate(bulletPrefab, transform.position + offset, Quaternion.identity); // Instantiate the bullet at the shooter's position + offset
            Vector2 direction = (player.position - transform.position).normalized; // Calculate the direction to the player

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bullet
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed; // Set the bullet's velocity towards the player
                SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>(); // Get the SpriteRenderer of the bullet
                SpriteRenderer shooterSpriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer of the shooter

                if (bulletSpriteRenderer != null && shooterSpriteRenderer != null)
                {
                    bulletSpriteRenderer.color = shooterSpriteRenderer.color; // Set the bullet's color to match the shooter's color
                }
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody2D component attached.");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }
}
