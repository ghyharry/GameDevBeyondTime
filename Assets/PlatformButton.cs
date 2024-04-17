using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the button, the platform will disappear
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            platform.SetActive(false);
        }
    }
}
