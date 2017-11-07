using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapSpot : MonoBehaviour
{

    public Color hover_color; //the color of the spot once the player hovers the cursor over this building spot.
    public Color insufficient_color; //the color of the spot if the player hovers the cursor over this building spot and doesn't have enough money.
    private Color original_color; //the first color of the node. this is used to return the color back once the player isn't hovering over the node.

    public Vector3 offset; //the offset to properly build the turret ontop of this spot.
    private Renderer rendr; //the renderer to change the color of the building spot.

    [HideInInspector]
    public GameObject trap; //this is used to keep track of the tower that is built on this spot.
    [HideInInspector]
    public TrapBlueprint trap_blueprint; //the current trap blueprint to remember what kind of turret is built on this spot.
    

    buildmanager buildmanager_script; //used to access the build manager script

    public Vector3 GetBuildPosition() //this will give the build position of where to place the turret.
    {
        //this will give the position of this spot with the additional offset to give the proper building spot.
        return transform.position + offset;
    }

    void BuildTrap(TrapBlueprint _blueprint)
    {
        //check if the player has enough money to build. otherwise nothing happens and an error message happens.
        if (PlayerStats.money < _blueprint.cost)
        {
            Debug.Log("Not enough money to build.");
            return;
        }

        //otherwise, remove their money from the cost and build them the tower.
        PlayerStats.money -= _blueprint.cost;
        GameObject _trap = (GameObject)Instantiate(_blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        trap = _trap;

        trap_blueprint = _blueprint;

    }

    
    void OnMouseEnter()
    {
        //blocks the player if they are hovering over a UI overlay.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if the player can't build the tower, then nothing happens and exit now.
        if (!buildmanager_script.CanBuildTrap)
            return;

        //if the player has enough money to build, then it will change the color of the spot to grey.
        if (buildmanager_script.HasMoneyTrap)
        {
            rendr.material.color = hover_color;
        }
        else
        {
            //otherwise they did not have enough money. it will change into red.
            rendr.material.color = insufficient_color;
        }
    }

    void OnMouseExit()
    {
        //once the player no longer hovers over the building spot, return to its original color.
        rendr.material.color = original_color;
    }


    void OnMouseDown()
    {
        //blocks the player if they are hovering over a UI overlay.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if there is already a turret, then it will select the node instead.
        if (trap != null)
        {
            return;
        }

        //if the player aren't able to build, then exit out now.
        if (!buildmanager_script.CanBuildTrap)
            return;

        //otherwise, build the selected turret on top of this node.
        BuildTrap(buildmanager_script.GetTrapToBuild());

    }

    void Start()
    {
        //creates the build manager singleton.
        buildmanager_script = buildmanager.S;
        //gets the renderer of this building spot.
        rendr = GetComponent<Renderer>();
        //save the original color information.
        original_color = rendr.material.color;

    }
}
