using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Proyecto26;

[System.Serializable]
public class PlayerDeathLocData
{
    public float x;
    public float y;
}

public class GameManager : MonoBehaviour
{

    public bool isCurrentTimeLine = true;
    public Vector3 playerPos;

    public GameObject current;
    public GameObject past;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
        TimeSwitch();
    }

    void TimeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCurrentTimeLine = !isCurrentTimeLine;
            if (isCurrentTimeLine)
            {
                Debug.Log("Game Manager: Current. ");
                current.SetActive(true);
                past.SetActive(false);
            }
            else
            {
                Debug.Log("Game Manager: Past. ");
                current.SetActive(false);
                past.SetActive(true);
            }
            Debug.Log("C is pressed. ");
            //isCurrentTimeLine = !isCurrentTimeLine;
            Debug.Log("the bool variable is : " + isCurrentTimeLine);
        }
    }

    public void DeathAnalytics(Vector3 playerPos)
    {
        PlayerDeathLocData pdata = new PlayerDeathLocData();
        pdata.x = playerPos.x;
        pdata.y = playerPos.y;
        string json = JsonUtility.ToJson(pdata);
        RestClient.Post("https://team-3g-default-rtdb.firebaseio.com/.json", pdata);
    }
}