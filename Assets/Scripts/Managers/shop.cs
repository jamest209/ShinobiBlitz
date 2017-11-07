using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {

    public TurretBlueprint archer_tower;
    public TurretBlueprint slauncher;
    public TurretBlueprint flame_tower;
    public TurretBlueprint mortar_tower;
    public TrapBlueprint spike_trap;
    public TrapBlueprint oil_trap;
    public TrapBlueprint static_trap;

    public static bool archer_selected, slauncher_selected, flame_selected, mortar_selected;

    buildmanager buildmanager_script;

    void Start()
    {
        buildmanager_script = buildmanager.S;
    }

	public void SelectArcherTower()
    {
        buildmanager_script.SelectTurretToBuild(archer_tower);
        archer_selected = true;
        slauncher_selected = false;
        flame_selected = false;
        mortar_selected = false;
    }

    public void SelectShurikenLauncher()
    {
        buildmanager_script.SelectTurretToBuild(slauncher);
        archer_selected = false;
        slauncher_selected = true;
        flame_selected = false;
        mortar_selected = false;
    }

    public void SelectFlameTower()
    {
        buildmanager_script.SelectTurretToBuild(flame_tower);
        archer_selected = false;
        slauncher_selected = false;
        flame_selected = true;
        mortar_selected = false;
    }

    public void SelectMortarTower()
    {
        buildmanager_script.SelectTurretToBuild(mortar_tower);
        archer_selected = false;
        slauncher_selected = false;
        flame_selected = false;
        mortar_selected = true;
    }

    public void SelectSpikeTrap()
    {
        buildmanager_script.SelectTrapToBuild(spike_trap);
        archer_selected = false;
        slauncher_selected = false;
        flame_selected = false;
        mortar_selected = false;
    }

    public void SelectOilTrap()
    {
        buildmanager_script.SelectTrapToBuild(oil_trap);
        archer_selected = false;
        slauncher_selected = false;
        flame_selected = false;
        mortar_selected = false;
    }

    public void SelectStaticTrap()
    {
        buildmanager_script.SelectTrapToBuild(static_trap);
        archer_selected = false;
        slauncher_selected = false;
        flame_selected = false;
        mortar_selected = false;
    }
}
