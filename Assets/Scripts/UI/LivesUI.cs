using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text lives_text;

    // Update is called once per frame
    void Update()
    {
        lives_text.text = "Lives: " + PlayerStats.lives.ToString();
    }
}
