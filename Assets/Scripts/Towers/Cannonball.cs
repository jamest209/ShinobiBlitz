using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {

    
    private float current_timer = 0f;
    public Color explosion_color;
    public int damage = 15;


    private Renderer rendr; //the renderer to change the color of the cannonball on explosion.
    [HideInInspector]
    public enemy enemy_script;
    [HideInInspector]
    public enemy2 enemy_script2;
    [HideInInspector]
    public bool exploding = false;
    [HideInInspector]
    public Rigidbody rb;

    void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            if (col.gameObject.tag == "Enemy")
            {
                enemy_script = col.GetComponent<enemy>();
                enemy_script.ReceiveDamage(damage);
                exploding = true;
                rb.isKinematic = true;
                rendr.material.color = explosion_color;
            }

            if (col.gameObject.tag == "Enemy2")
            {
                enemy_script2 = col.GetComponent<enemy2>();
                enemy_script2.ReceiveDamage(damage);
                exploding = true;
                rb.isKinematic = true;
                rendr.material.color = explosion_color;
            }
        }
    }

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rendr = GetComponent<Renderer>();
        Destroy(gameObject, 25f);
    }

    void Update()
    {
        if(exploding)
        {
            current_timer += Time.deltaTime;
            transform.localScale += new Vector3(5.5f, 5.5f, 5.5f) * Time.deltaTime;
            if (current_timer > .5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
