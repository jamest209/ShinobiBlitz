using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject[] levels;
    public int current_level = 0;
    public GameObject cur_levelGO;
    public GameObject MainMenu;


    public void GoToMain()
    {
        Destroy(cur_levelGO);
        cur_levelGO = Instantiate(MainMenu, Vector3.zero, Quaternion.identity);
        wavespawner.enemy_remaining = 0;
    }

    public void StartGame()
    {
        current_level = 0;
        Destroy(cur_levelGO);
        cur_levelGO = Instantiate(levels[current_level], Vector3.zero, Quaternion.identity);
    }

    public void StartNextLevel()
    {
        if(cur_levelGO != null)
        {
            Destroy(cur_levelGO);
        }
        current_level++;
        if(current_level == levels.Length)
        {
            current_level = 0;
        }
        cur_levelGO = Instantiate(levels[current_level], Vector3.zero, Quaternion.identity);
        wavespawner.enemy_remaining = 0;
    }

    public void RestartLevel()
    {
        Destroy(cur_levelGO);
        cur_levelGO = Instantiate(levels[current_level], Vector3.zero, Quaternion.identity);
        wavespawner.enemy_remaining = 0;
    }

    private void Awake()
    {
        cur_levelGO = GameObject.Find("MainMenu");
    }
}
