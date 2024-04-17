using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootColor : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;

    public int bulletsInT1Count = 0;
    public int bulletsInT2Count = 0;



    public GameManager gameManager;
    public GameManager gameManagerScript;

    // Bullet speed
    public float bulletSpeed = 10f;

    //Shoot offset from the player direction
    public Vector3 shootOffset = new Vector3(2f, 0, 0);


    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // Check for spacebar to shoot
        if (Input.GetKeyDown(KeyCode.M)) // Fire1 is usually mapped to Ctrl and mouse left click
        {
            if (gameManagerScript.isCurrentTimeLine)
            {
                Debug.Log("The timeline from shootcolor is : " + gameManagerScript.isCurrentTimeLine);
                bulletsInT1Count += 1;
                Shoot();
            }
            else
            {
                bulletsInT2Count += 1;
                Shoot();
            }
            
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
            bullet.GetComponent<Bullet>().savedDirection = shootDirection;
            bullet.GetComponent<Bullet>().speed = bulletSpeed;
            bullet.GetComponent<Bullet>().UpdateVelocity();
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }
}
