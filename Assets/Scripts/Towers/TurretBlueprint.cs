using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurretBlueprint{

    public GameObject prefab;

    public int cost;

    public GameObject upgraded_prefab;

    public int upgrade_cost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

	
}
