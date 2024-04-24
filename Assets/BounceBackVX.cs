using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBackVX : MonoBehaviour
{
    // Start is called before the first frame update
    private float effectTimer = 0.0f;
    //Save original color
    private Color originalColor;
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(effectTimer > 0.0f)
        {
            effectTimer -= Time.deltaTime;
            if(effectTimer <= 0.0f)
            {
                //Reset the timer
                effectTimer = 0.0f;
                //Reset the color
                GetComponent<SpriteRenderer>().material.color = originalColor;
            }
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PastBoss")
        {
            // Make game object flash white
            FlashWhite();
            Debug.Log("BounceBackVX: Collision with Player");
        }
    }

    void FlashWhite()
    {
        // Change color to white
        GetComponent<SpriteRenderer>().material.color = Color.white;

        // Set timer
        effectTimer = 0.15f;
    }
}
