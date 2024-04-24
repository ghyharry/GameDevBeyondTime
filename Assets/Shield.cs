using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject hatPrefab;

    // Start is called before the first frame update
    void Start()
    {
        hatPrefab.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // If the player collides with the shield
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Get takedamageplayer script
            takedamageplayer takedamageplayer = collision.gameObject.GetComponent<takedamageplayer>();
            takedamageplayer.damageMax = 2;

            // Set player color to pink
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            hatPrefab.SetActive(true);

            // Destroy the shield
            Destroy(gameObject);
        }
    }
    public void OnDestroy()
    {
        //destroyed.
    }
}
