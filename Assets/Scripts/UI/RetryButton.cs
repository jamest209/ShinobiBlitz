using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

    
    public GameObject GameOverUI;
    public LevelManager level_scr;
    public GameObject BuildList;
    public GameObject HowToPlayGO, HowToPlayGO2, main_menu_image, main_menu_buttons;

    private void Awake()
    {
        level_scr = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        BuildList = GameObject.Find("BuildList");
    }

    private void DestroyBuildings()
    {
        foreach (Transform child in BuildList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void Retry()
    {
        level_scr.RestartLevel();
        DestroyBuildings();
        if(Pause.paused)
        {
            Pause.TogglePause();
        }
    }

    public void NextLevel()
    {
        level_scr.StartNextLevel();
        DestroyBuildings();
        if (Pause.paused)
        {
            Pause.TogglePause();
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Quit()
    {
        level_scr.GoToMain();
        DestroyBuildings();
        if (Pause.paused)
        {
            Pause.TogglePause();
        }
    }

    public void CloseHowToPlay()
    {
        HowToPlayGO2.SetActive(false);
        main_menu_buttons.SetActive(true);
        main_menu_image.SetActive(true);
    }

    public void Resume()
    {
        if (Pause.paused)
        {
            Pause.TogglePause();
        }
    }

    public void StartGame()
    {
        level_scr.StartGame();
        DestroyBuildings();
        if (Pause.paused)
        {
            Pause.TogglePause();
        }
    }

    public void HowToPlay()
    {
        HowToPlayGO.SetActive(true);
        main_menu_buttons.SetActive(false);
        main_menu_image.SetActive(false);
    }

    public void HowToPlay2()
    {
        HowToPlayGO.SetActive(false);
        HowToPlayGO2.SetActive(true);
    }
    
}
