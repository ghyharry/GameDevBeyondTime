using UnityEngine;

public class ShootColorAtPlayer : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to shoot
    public GameObject shootingEnemy;
    GameObject[] bulletArray;
    public Transform player; // The player's transform
    public float shootInterval = 2f; // Time between shots
    public float bulletSpeed = 5f; // Speed of the bullet

    private float shootTimer; // Timer to track shooting intervals

    void Start()
    {
        shootTimer = shootInterval; // Initialize the shoot timer
        shootingEnemy = this.gameObject;
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
            bullet.transform.SetParent(shootingEnemy.transform); //set the bullets as child of enemy.
            Vector2 direction = (player.position - transform.position).normalized; // Calculate the direction to the player

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bullet
            bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
            Debug.Log("The bullet array is : " + bulletArray.Length);

            if (rb != null)
            {
                for(int i = 0;i < bulletArray.Length; i++)
                {
                    if (bulletArray[i].active)
                    {
                        bulletArray[i].GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                    }
                }
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
    private void OnEnable()
    {
        //ShootAtPlayer();
        Vector2 direction = (player.position - transform.position).normalized; // Calculate the direction to the player
        for (int i = 0; i < bulletArray.Length; i++)
        {
            bulletArray[i].GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        /*shootTimer = 0; // Decrease the timer by the time passed since last frame

        if (shootTimer <= 0 && player != null)
        {
            ShootAtPlayer(); // Shoot a bullet at the player
            shootTimer = shootInterval; // Reset the timer
        }*/
    }
}
