using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    bool isPaused = false;
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartBehavior()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
        //gameObject.SetActive(false);
    }

    public void WinCondition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LastSceneWinCondition()
    {

        SceneManager.LoadScene(0);
        
    }
    public void PauseButtonOnClick()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseCanvas.SetActive(isPaused);
    }
    public void ContinueButtonOnClick()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(isPaused);
    }
    public void MainMenuOnClick()
    {
        SceneManager.LoadScene(0);

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
    }
}
