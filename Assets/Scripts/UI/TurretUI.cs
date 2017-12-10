using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour {

    public GameObject ui;

    public Text upgrade_cost;
    public Button upgrade_button;

    public Text sell_amount;

    private spots target;
    private bool selected = false;

    public void SetTarget(spots _target)
    {
        //passes in the target to this script.
        target = _target;
        //set the position of the UI to the node
        transform.position = target.GetBuildPosition();

        //update the cost to upgrade text into the upgrade button
        if(!target.is_upgraded)
        {
            upgrade_cost.text = "$" + target.turret_blueprint.upgrade_cost;
            upgrade_button.interactable = true;
        }
        else
        {
            upgrade_cost.text = "MAXED";
            upgrade_button.interactable = false;
        }

        //update the sell amount to the sell text in UI.
        sell_amount.text = "$" + target.turret_blueprint.GetSellAmount();
        
        //reveal the UI for the player
        ui.SetActive(true);

        selected = true;
    }

    public void Hide()
    {
        //turns off the UI so it doesn't get in the way.
        ui.SetActive(false);
        selected = false;
    }

    public void Upgrade()
    {
        //calls the upgrade function from the spots script on this specific tower.
        target.UpgradeTurret();
        //deselect the node after building the tower so the UI isn't here after the old tower is destroyed.
        buildmanager.S.DeselectNode();
        selected = false;
    }

    public void Rotate()
    {
        target.RotateTurret();
    }

    public void Sell()
    {
        //calls the sell function from the spots script on this tower.
        target.SellTurret();
        //deselect the node after destroying the tower so UI isn't here after the tower is gone.
        buildmanager.S.DeselectNode();
        selected = false;
    }

    private void Update()
    {
        if(target != null)
        {
            if (Input.GetKeyDown(KeyCode.R) && selected)
            {
                target.RotateTurret();
            }
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
            {
                buildmanager.S.DeselectNode();
                selected = false;
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Upgrade();
            }
        }
    }
}
