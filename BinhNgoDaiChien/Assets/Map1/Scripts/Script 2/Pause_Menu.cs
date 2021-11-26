using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject player;

    Player_Health playerUI;

    void Start()
    {
        playerUI = player.GetComponent<Player_Health>();
    }

    public void Resume()
    {
        if (playerUI.getCurrentHealth() > 0)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else RestartScene();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //SceneManager.LoadScene("Menu");
    }

    public void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
    }
}
