using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTower : MonoBehaviour {

    public spots spots_scr;

    public void pass_spots(spots _myspot)
    {
        spots_scr = _myspot;
    }

    public void OnMouseDown()
    {
        spots_scr.Click();
    }

}
