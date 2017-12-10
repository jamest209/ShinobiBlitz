using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyUI : MonoBehaviour {

    public Text SupplyUI_text;
	
	// Update is called once per frame
	void Update () {

        if(PlayerStats.building_amount == PlayerStats.building_limit)
        {
            SupplyUI_text.color = Color.red;
        }
        else
        {
            SupplyUI_text.color = Color.white;
        }

        SupplyUI_text.text = "Towers: " + PlayerStats.building_amount.ToString() + " / " + PlayerStats.building_limit.ToString();
	}
}
