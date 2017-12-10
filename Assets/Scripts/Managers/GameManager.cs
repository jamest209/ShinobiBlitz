using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject GameOverUI;
    public GameObject VictoryUI;
    public static bool win_game = false;

    public static bool game_ended;
    public int level_number;
    public GameObject[] levels;

    void Start()
    {
        game_ended = false;
    }

    void Victory()
    {
        game_ended = true;
        VictoryUI.SetActive(true);
    }

	void Update ()
    {
		if(PlayerStats.lives <= 0)
        {
            GameOverUI.SetActive(true);
            game_ended = true;
        }
        else if(win_game)
        {
            Victory();
            win_game = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !Pause.paused)
        {
            wavespawner.check_to_start_wave = true;
        }
    }
}
