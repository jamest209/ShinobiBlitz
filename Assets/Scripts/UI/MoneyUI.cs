using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyUI : MonoBehaviour {

    public Text money_text;
	
	// Update is called once per frame
	void Update () {
        money_text.text = "$" + PlayerStats.money.ToString();
	}
}
