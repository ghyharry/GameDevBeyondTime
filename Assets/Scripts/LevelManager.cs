using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartBehavior()
    {
        SceneManager.LoadScene(0);
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
}
