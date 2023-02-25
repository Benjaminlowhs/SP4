using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject crosshair;

    public GameObject bgmController;
    public GameObject CraftingPanel;
    public GameObject optionsMenuUI;
    public GameObject inventoryUI;
    

    public PlayerInteractUI playerInteract;
    public CraftingInteractable craftingInteract;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!CraftingPanel.activeSelf)
            {
                if (!optionsMenuUI.activeSelf)
                {
                    if (GameIsPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                        AudioSource[] audios = FindObjectsOfType<AudioSource>();

                        foreach ( AudioSource a in audios)
                        {
                            a.Pause();
                        }
                    }
                }
                else
                {
                    pauseMenuUI.SetActive(true);
                    optionsMenuUI.SetActive(false);
                }
            }
            else
            {
                playerInteract.Hide();
                inventoryUI.SetActive(false);
                CraftingPanel.SetActive(false);
                craftingInteract.HidePanel();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);
        bgmController.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        crosshair.SetActive(false);
        bgmController.SetActive(false);
    }

    public void LoadOptions()
    {
            
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
    }
}
