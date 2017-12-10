using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public enemy enemy_scr;
    public enemy2 enemy2_scr;
    public Transform target;

	// Use this for initialization
	void Start () {
        if(transform.parent.gameObject.tag == "Enemy")
        {
            enemy_scr = transform.parent.GetComponent<enemy>();
        }
        else
        {
            enemy2_scr = transform.parent.GetComponent<enemy2>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(enemy_scr!= null)
        {
            target = enemy_scr.target;
        }
        else
        {
            target = enemy2_scr.target;
        }

        transform.LookAt(target); //rotate to look at the next destination
    }
}
