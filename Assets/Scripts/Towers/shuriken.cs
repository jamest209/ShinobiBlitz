using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour {

    private Transform target;
    public float speed = 20f;
    public int damage = 5;
    public GameObject damage_effect;
    public enemy enemy_script;
    public enemy2 enemy_script2;
    private Vector3 dir;

    public void Chase(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        Destroy(gameObject, .45f);
        dir = target.position - transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        { 
            GameObject effect = (GameObject)Instantiate(damage_effect, transform.position, transform.rotation);
            Destroy(effect, 1f);

            
            enemy_script = col.GetComponent<enemy>();
            enemy_script.ReceiveDamage(damage);

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy2")
        {
            GameObject effect = (GameObject)Instantiate(damage_effect, transform.position, transform.rotation);
            Destroy(effect, 1f);

           
            enemy_script2 = col.GetComponent<enemy2>();
            enemy_script2.ReceiveDamage(damage);

            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        
        float current_distance = speed * Time.deltaTime;

        transform.Translate(dir.normalized * current_distance, Space.World);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 55, 0);
    }
}
