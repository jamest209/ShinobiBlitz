using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public static int lives;
    public int start_lives = 5;
    public int start_money = 200;

    

	// Use this for initialization
	void Start ()
    {
        money = start_money;
        lives = start_lives;
	}
	
    public static void lose_life()
    {
        lives -= 1;
        if (lives < 0)
        {
            lives = 0;
        }
    }

}
