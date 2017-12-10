using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public static int lives;
    public static int building_amount;
    public static int building_limit;

    public int start_lives = 5;
    public int start_money = 200;
    private int start_building = 0;
    public int building_limit_level = 15;
    

	// Use this for initialization
	void Start ()
    {
        money = start_money;
        lives = start_lives;
        building_amount = start_building;
        building_limit = building_limit_level;
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
