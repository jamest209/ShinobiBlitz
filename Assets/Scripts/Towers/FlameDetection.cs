using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDetection : MonoBehaviour {

    public FlameTower FT_scr;

    void Start()
    {
        FT_scr = transform.parent.GetComponent<FlameTower>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy2")
        {
            Debug.Log("Target is: " + col);
            FT_scr.target = col.transform;
        }
        
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Target has left.");
        FT_scr.target = null;
    }
}
