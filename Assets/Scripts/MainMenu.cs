using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenuCanvas;
    public GameObject levelsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOnClick()
    {
        mainMenuCanvas.SetActive(false);
        levelsCanvas.SetActive(true);


    }

    public void ExitOnClick()
    {
        Debug.Log("Game exited. ");
        Application.Quit();
    }

    public void TutorialObstacleOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialBounceOnClick()
    {
        SceneManager.LoadScene(2);
    }
    public void TutorialEnemyOnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelOnClick()
    {
        SceneManager.LoadScene(4);
    }

    
}
