using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSHintTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        //Get the game manager with cast
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger");
            gameManager.EnableTimeIndicator();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the trigger");
            gameManager.DisableTimeIndicator();
        }
    }

}
