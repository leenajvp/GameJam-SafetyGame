using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu = null;
    [SerializeField] private GameObject CreditsMenu = null;
    private bool paused = false;

    private void Start()
    {
        PauseMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (paused)
            {
                PauseMenu.SetActive(false);
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitPause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenCreditsMenu()
    {
        CreditsMenu.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SpawnPoint", 0);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
