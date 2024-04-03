using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootColor : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;

    // Bullet speed
    public float bulletSpeed = 10f;

    //Shoot offset from the player direction
    public Vector3 shootOffset = new Vector3(2f, 0, 0);

    // Update is called once per frame
    void Update()
    {
        // Check for spacebar to shoot
        if (Input.GetButtonDown("Fire1")) // Fire1 is usually mapped to Ctrl and mouse left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Ensure there's a bullet prefab assigned
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

            // Add velocity to the bullet Rigidbody2D component to shoot it
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootDirection * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab is missing a Rigidbody2D component.");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }
}
