using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Time.timeScale = 1f;
        }
    }
}
