using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Proyecto26;

[System.Serializable]
public class PlayerDeathLocData
{
    public float x;
    public float y;
}

[System.Serializable]
public class LevelTimerData
{
    public float totalLevelTimerData;
    public float timeInT1;
    public float timeInT2;
    public string levelName;
}

[System.Serializable]
public class PlayerInfoDataStruct
{
    public int bulletCountInT1;
    public int bulletCountInT2;
    public int enemiesHitInT1;
    public int enemiesHitInT2;
    //public int deathCount;
    public string levelName;
}

[System.Serializable]
public class TimeInFrontOfObstacleStruct
{
    public float[] timeInFrontOfObstacles;
    public string[] obstacleName;
    public string levelName;
}

public class GameManager : MonoBehaviour
{

    public bool isCurrentTimeLine = true;
    public int numberOfEnemiesHitInT1;
    public int numberOfEnemiesHitInT2;

    public Vector3 playerPos;

    public GameObject current;
    public GameObject past;
    public GameObject player;
    //public CustomSceneManager sceneOne;


    private string deathLocationJsonFile = "DeathLocation.json";
    private string totalLevelJsonFile = "LevelTime.json";
    private string playerInfoJsonFile = "PlayerGameInfo.json";
    private string timeInFrontOfObstacleJsonFile = "TimeAtObstacle.json";

    private void Start()
    {
        numberOfEnemiesHitInT1 = 0;
        numberOfEnemiesHitInT2 = 0;
        //sceneOne = sceneOne.GetComponent<CustomSceneManager>();

    }
    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        TimeSwitch();
    }

    void TimeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        RestClient.Post("https://team-3g-default-rtdb.firebaseio.com/"+ deathLocationJsonFile, pdata);
    }
    public void TimeInEachLevel(float totalLevelTimer, float timeInT1, float timeInT2, string sceneName)
    {
        LevelTimerData lTimer = new LevelTimerData();
        lTimer.totalLevelTimerData = totalLevelTimer;
        lTimer.timeInT1 = timeInT1;
        lTimer.timeInT2 = timeInT2;
        lTimer.levelName = sceneName;
        RestClient.Post("https://team-3g-default-rtdb.firebaseio.com/" + totalLevelJsonFile, lTimer);
    }
    public void PlayerInfoData(int bulletCountInT1, int bulletCountInT2, string sceneName)
    {
        //Debug.Log("The number of enemies killed is : " + numberOfEnemiesKilled);
        PlayerInfoDataStruct playerInfo = new PlayerInfoDataStruct();
        playerInfo.bulletCountInT1 = bulletCountInT1;
        playerInfo.bulletCountInT2 = bulletCountInT2;
        playerInfo.enemiesHitInT1 = numberOfEnemiesHitInT1;
        playerInfo.enemiesHitInT2 = numberOfEnemiesHitInT2;

        playerInfo.levelName = sceneName;
        RestClient.Post("https://team-3g-default-rtdb.firebaseio.com/" + playerInfoJsonFile, playerInfo);
        numberOfEnemiesHitInT1 = 0;
        numberOfEnemiesHitInT2 = 0;
    }

    public void TimeInFrontOfObstacle(float[] timer, string[] obstacleName, string levelName)
    {
        TimeInFrontOfObstacleStruct obstTime = new TimeInFrontOfObstacleStruct();
        obstTime.timeInFrontOfObstacles = timer;
        obstTime.obstacleName = obstacleName;
        obstTime.levelName = levelName;
        RestClient.Post("https://team-3g-default-rtdb.firebaseio.com/" + timeInFrontOfObstacleJsonFile, obstTime);

    }
}