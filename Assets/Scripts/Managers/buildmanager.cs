using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour {

    public static buildmanager S; //build manager singleton

    private TurretBlueprint build_turret;
    private TrapBlueprint build_trap;
    private spots selected_node;

    public TurretUI turretUI;

    public bool CanBuild { get { return build_turret != null; } }

    public bool CanBuildTrap { get { return build_trap != null; } }

    public bool HasMoney { get { return PlayerStats.money >= build_turret.cost; } }

    public bool HasMoneyTrap { get { return PlayerStats.money >= build_trap.cost; } }

    void Awake () {
        S = this; 
	}
	
	public TurretBlueprint GetTurretToBuild()
    {
        return build_turret;
    }

    public TrapBlueprint GetTrapToBuild()
    {
        return build_trap;
    }

    public void SelectTurretToBuild(TurretBlueprint _turret)
    {
        build_turret = _turret;
        selected_node = null;
        build_trap = null;
        DeselectNode();
    }

    public void SelectTrapToBuild(TrapBlueprint _trap)
    {
        build_trap = _trap;
        selected_node = null;
        build_turret = null;
        DeselectNode();
    }

    public void SelectNode (spots _spot)
    {
        if(selected_node == _spot)
        {
            DeselectNode();
            return;
        }

        selected_node = _spot;
        build_turret = null;
        build_trap = null;
        turretUI.SetTarget(_spot);
        shop.archer_selected = false;
        shop.slauncher_selected = false;
        shop.flame_selected = false;
        shop.mortar_selected = false;
    }



    public void DeselectNode()
    {
        selected_node = null;
        turretUI.Hide();
        shop.archer_selected = false;
        shop.slauncher_selected = false;
        shop.flame_selected = false;
        shop.mortar_selected = false;
    }
}
