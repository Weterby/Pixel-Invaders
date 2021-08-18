using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private bool isScenePaused = false;
    [SerializeField]
    private GameObject mainPage;
    [SerializeField]
    private GameObject options;

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isScenePaused = false;
    }

    public void PauseGame()
    {
        isScenePaused = true;
        Time.timeScale = 0f;
        mainPage.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && CanPause())
        {
            PauseGame();
        }
    }

    private bool CanPause()
    {
        if(SceneManager.GetActiveScene().name == "GameScene" && !isScenePaused)
        {
            return true;
        }
        return false;
    }
}
