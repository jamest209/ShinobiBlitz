using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour {

    public static CannonManager S; //build manager singleton

    public bool can_fire = true;
    public float cooldown_timer = 3f;
    public float current_timer = 0f;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start () {
        can_fire = true;
	}
	
    //a function that returns if the cannon can fire. will be used to check before firing the cannon.
    public bool CanFire()
    {
        return can_fire;
    }

	

    void Update()
    {
        if(current_timer <= 0 && !can_fire)
        {
            can_fire = true;
        }

        if(!can_fire)
        {
            current_timer -= Time.deltaTime;
        }
    }
}
