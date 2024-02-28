using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private int hitCount = 0; // Tracks the number of hits

    public int damageMax; // Maximum number of hits before object is destroyed
    public int damageWeak; // Number of hits before object enters weak state

    public GameObject restartUI; // UI to display when player is destroyed

    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet DAMAGE detected");

            //Destroy the bullet
            Destroy(collision.gameObject);

            hitCount++; // Increment hit count

            // Check if hit count is equal to 3
            if (hitCount == damageWeak)
            {
                Debug.Log("In weak state");
                //if the object tag is "Enemy", set the tag to "EnemyWeak"
                if (gameObject.CompareTag("Enemy"))
                {
                    gameObject.tag = "EnemyWeak";
                }
                
                // Get current objects Halo component
                Behaviour halo = (Behaviour)GetComponent("Halo");
                
                //If it has a halo component
                if (halo != null)
                {
                    //Change halo size to 5
                    halo.enabled = false;
                }
                

            }
            // Check if hit count is equal to or exceeds 5
            else if (hitCount >= damageMax)
            {
                Destroy(gameObject); // Destroy the object
                //If the object is the player, display the restart UI
                if (gameObject.CompareTag("Player"))
                {
                    restartUI.SetActive(true);
                }
            }
        }
    }
}
