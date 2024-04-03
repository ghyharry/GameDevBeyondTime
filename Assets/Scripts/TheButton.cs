using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PastBoss" || collision.collider.tag == "CurrentBoss"|| collision.collider.tag == "Player")
        {
            //platform movement functionality
            platform.SetActive(false);

            //Debug.Log("Button collision. ");
        }
    }
}
