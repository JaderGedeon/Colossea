using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool Jogo_Pausado = false;

    public GameObject pauseMenuUI;
    public GameObject GUI;
    public GameObject confirm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Jogo_Pausado)
                Resume();
            else
                Pause();
        }        
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        GUI.SetActive(true);
        Time.timeScale = 1f;
        Jogo_Pausado = false;
    }

    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0f;
        Jogo_Pausado = true;
    }

    public void Carregar_Menu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void Confirm() 
    {
        confirm.SetActive(true);
    }

    public void ReturnConfirm()
    {
        confirm.SetActive(false);
    }
}
