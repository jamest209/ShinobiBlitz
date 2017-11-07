using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathwaySpots : MonoBehaviour {

    public Color hover_color; //the color of the spot once the player hovers the cursor over this pathway spot and can fire.
    public Color insufficient_color; //the color of the spot if the player hovers the cursor over this pathway spot and can't fire.
    private Color original_color; //the first color of the node. this is used to return the color back once the player isn't hovering over the node.
    private Renderer rendr; //the renderer to change the color of the pathway spot.

    private Vector3 offset = Vector3.zero; //the offset to properly fire a bullet ontop of this spot.

    CannonManager CannonManager_script; //used to access the build manager script
    public GameObject cannonball_prefab;

    public Vector3 GetFirePosition() //this will give the build position of where to place the turret.
    {
        //this will give the position of this spot with the additional offset to give the proper building spot.
        return transform.position + offset;
    }

    public void Fire(PathwaySpots spot)
    {
        CannonManager_script.can_fire = false;
        //fire a cannonball prefab
        GameObject c_ball = (GameObject)Instantiate(cannonball_prefab, GetFirePosition(), Quaternion.identity);
        CannonManager_script.current_timer = CannonManager_script.cooldown_timer;
    }

    void OnMouseEnter()
    {
        //blocks the player if they are hovering over a UI overlay.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if the player can't fire, then nothing happens and exit now.
        if (!CannonManager_script.CanFire())
        {
            rendr.material.color = insufficient_color;
            return;
        }

        //if the player is able to fire, then it will change the color of the spot to green.
        if (CannonManager_script.CanFire())
        {
            rendr.material.color = hover_color;
        }

    }


    void OnMouseExit()
    {
        //once the player no longer hovers over the pathway spot, return to its original color.
        rendr.material.color = original_color;
    }

    void OnMouseDown()
    {
        //blocks the player if they are hovering over a UI overlay.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!CannonManager_script.CanFire())
        {
            Debug.Log("Cant fire yet.");
            return;
        }
        Fire(this);

    }

    void Start()
    {
        //creates the cannon manager singleton.
        CannonManager_script = CannonManager.S;
        //gets the renderer of this building spot.
        rendr = GetComponent<Renderer>();
        //save the original color information.
        original_color = rendr.material.color;

    }
}
