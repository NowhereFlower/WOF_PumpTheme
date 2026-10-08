using UnityEngine;
using UnityEngine.SceneManagement;

public class SGameEvent : MonoBehaviour
{



    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject losePanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }
    public void TryAgain()
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene(1);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


   public void PauseScreen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPauseScreen()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
