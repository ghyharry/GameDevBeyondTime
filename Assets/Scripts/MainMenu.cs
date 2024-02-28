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

    public void TutorialOnClick()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
