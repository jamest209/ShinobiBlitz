using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public float speed = 20f;

    public float border_padding = 10f;

    public int screen_limit = 20;

    public float scroll_vertical_speed = 5000f;

    public float max_height = 25f;
    public float min_height = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - border_padding)
        {
            if (this.transform.position.z < screen_limit)
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= border_padding)
        {
            if (this.transform.position.z > -screen_limit)
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= border_padding)
        {
            if (this.transform.position.x > -screen_limit)
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - border_padding)
        {
            if (this.transform.position.x < screen_limit)
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        //Mouse ScrollWheel
        float scroll_value = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll_value * scroll_vertical_speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, min_height, max_height);

        transform.position = pos;
    }
}
