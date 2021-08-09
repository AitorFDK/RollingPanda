using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtil : MonoBehaviour
{
    public GameObject pausaMenu;


    public static void Pause()
    {
        Time.timeScale = 0;
    }
    
    public static void Resume()
    {
        Time.timeScale = 1;
    }

    public void TogglePause() 
    {
        if (Time.timeScale == 0) {
            Resume();
            pausaMenu.SetActive(false);
        } 
        else {
            pausaMenu.SetActive(true);
            Pause();
        }
        
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void LevelReset()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }

       
}
