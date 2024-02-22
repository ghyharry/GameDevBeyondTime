using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool isCurrentTimeLine = true;
    public GameObject current;
    public GameObject past;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
}
