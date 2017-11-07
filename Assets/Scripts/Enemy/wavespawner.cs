using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour {

    public Wave[] waves;

    public float spawn_timer = 5f;
    public Text wave_countdown_text;
    public Text wave_number_text;
    public Transform spawn_point;
    public Transform spawn_point2;
    [HideInInspector]
    public enemy enemy_scr;
    [HideInInspector]
    public enemy2 enemy2_scr;
    
    public static int enemy_remaining = 0;

    private float countdown = 10f;
    private int wave_number = 0;
    private int wave_display = 0;
    public static bool check_to_start_wave;

    public bool spawning = false;
    

    void SpawnEnemy(GameObject enemy)
    {
        GameObject spawned_enemy = Instantiate(enemy, spawn_point.position, spawn_point.rotation);
        enemy_scr = spawned_enemy.GetComponent<enemy>();
        enemy_scr.IncreaseHealth(wave_number);

        enemy_remaining += 1;
    }

    void SpawnEnemy2(GameObject enemy2)
    {
        GameObject spawned_enemy2 = Instantiate(enemy2, spawn_point2.position, spawn_point2.rotation);
        enemy2_scr = spawned_enemy2.GetComponent<enemy2>();
        enemy2_scr.IncreaseHealth(wave_number);

        enemy_remaining += 1;
    }

    public IEnumerator SpawnWave()
    {
        spawning = true;
        Wave wave = waves[wave_number];
        for (int i = 0; i < wave.count; i++)
        {
            check_to_start_wave = false;
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        

    }

    public IEnumerator SpawnWave2()
    {
        spawning = true;
        Wave wave = waves[wave_number];
        for (int i = 0; i < wave.count2; i++)
        {
            check_to_start_wave = false;
            SpawnEnemy2(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        spawning = false;
        wave_number++;
    }

    private void Awake()
    {
        check_to_start_wave = false;
    }

    void Update()
    {
        if(!GameManager.game_ended)
        {
            if(enemy_remaining < 0)
            {
                enemy_remaining = 0;
            }

            if (wave_number == waves.Length && enemy_remaining <= 0 && !spawning)
            {
                //victory screen here
                wave_countdown_text.color = Color.green;
                wave_countdown_text.text = "Victory!";
                GameManager.win_game = true;
                GameManager.game_ended = true;
                this.enabled = false;
            }

            if (enemy_remaining > 0)
            {
                return;
            }

            if(enemy_remaining == 0 &&!spawning && !GameManager.game_ended)
            {
                wave_countdown_text.text = "Press Spacebar to Start";
            }

            if (check_to_start_wave && waves[wave_number] != null)
            {
                check_to_start_wave = false;
                wave_display++;
                wave_number_text.text = "Wave: " + wave_display.ToString();
                StartCoroutine(SpawnWave());
                StartCoroutine(SpawnWave2());

                wave_countdown_text.text = "Wave Started";
            }
            else
            {
                check_to_start_wave = false;
            }
                

            
	    }
    }
}
