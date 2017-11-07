using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectile : MonoBehaviour {

    public float current_timer = 0f;
    public Color explosion_color;
    public int damage = 15;
    public MortarTower mortar_scr;
    public Vector3 destination;
    public float duration = 1f;
    private Vector3 start_pos;
    private Transform end_pos;
    private float start_time;
    private float length;
    private float distance;
    private bool stop_chasing = false;


    private Renderer rendr; //the renderer to change the color of the cannonball on explosion.
    [HideInInspector]
    public enemy enemy_script;
    [HideInInspector]
    public enemy2 enemy_script2;
    [HideInInspector]
    public bool exploding = false;
    [HideInInspector]
    public Rigidbody rb;

    public void SetDestination(Transform target)
    {
        end_pos = target;
    }

    void OnTriggerEnter(Collider col)
    {
        exploding = true;
        rb.isKinematic = true;
        rendr.material.color = explosion_color;

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Pathway")
        {
            if (col.gameObject.tag == "Enemy")
            {
                enemy_script = col.GetComponent<enemy>();
                enemy_script.ReceiveDamage(damage);
            }

            if (col.gameObject.tag == "Enemy2")
            {
                enemy_script2 = col.GetComponent<enemy2>();
                enemy_script2.ReceiveDamage(damage);
            }
        }
    }

        

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rendr = GetComponent<Renderer>();
        start_pos = transform.position;
        start_time = Time.time;
        destination = end_pos.position;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if(destination != null)
        {
            distance = Vector3.Distance(transform.position, destination);
            if (distance < 0.2f)
            {
                stop_chasing = true;
            }
        }
        
        if(destination != null && !stop_chasing)
        {
            Vector3 center = (start_pos + destination) * 0.5F;
            center -= new Vector3(0, 1, 0);
            Vector3 riseRelCenter = start_pos - center;
            Vector3 setRelCenter = destination - center;
            float fracComplete = (Time.time - start_time) / duration;
            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;
        }
        else
        {
            //add fix here if neccessary
        }
        
        
        if (exploding)
        {
            current_timer += Time.deltaTime;
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            if (current_timer > .4f)
            {
                Destroy(gameObject);
            }
        }
    }
}
