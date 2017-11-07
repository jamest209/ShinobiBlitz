using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public float speed = 20f;

    public float border_padding = 10f;

    public int screen_limit = 20;
	
	void Update ()
    {
	    if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - border_padding)
        {
            if(this.transform.position.z < screen_limit)
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= border_padding)
        {
            if (this.transform.position.z > -screen_limit)
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= border_padding)
        {
            if (this.transform.position.x > -screen_limit)
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - border_padding)
        {
            if (this.transform.position.x < screen_limit)
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
    }
}
