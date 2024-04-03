using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    public float sceneTimer;
    public float tempTimer;
    public GameObject player;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.active)
        {
            sceneTimer += Time.deltaTime;
            tempTimer = sceneTimer;
            //Debug.Log("The timer for the level is : " + tempTimer);
        }
        else
        {
            sceneTimer = tempTimer;
            Debug.Log("The timer is off player is dead. "+sceneTimer);
            StartCoroutine(SendLevelTimerData());
            
        }
    }

    IEnumerator SendLevelTimerData()
    {
        //gameManager.TimeInEachLevel(sceneTimer);
        yield return new WaitForSeconds(1000);
        //Destroy(this);

    }

    private void OnDestroy()
    {
        Debug.Log("The timer when level1 ends is : " + sceneTimer);   
    }

}
