using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

    public GameObject GameOverUI;

    public void Retry()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        GameOverUI.SetActive(false);
        wavespawner.enemy_remaining = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
