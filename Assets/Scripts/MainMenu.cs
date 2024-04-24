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
    public void BackButton()
    {
        mainMenuCanvas.SetActive(true);
        levelsCanvas.SetActive(false);
    }

    public void ExitOnClick()
    {
        Debug.Log("Game exited. ");
        Application.Quit();
    }

    public void TutorialObstacleOnClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void TutorialBounceOnClick()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void TutorialEnemyOnClick()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void Level1OnClick()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void Level2OnClick()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void Level3OnClick()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
    public void Level4OnClick()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
    public void Level5OnClick()
    {
        SceneManager.LoadScene(8);
        Time.timeScale = 1;
    }


}
