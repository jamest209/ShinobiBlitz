using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;
    public float speed = 20f;
    public int damage = 9;
    public GameObject damage_effect;
    public enemy enemy_script;
    public enemy2 enemy_script2;

    public void Chase(Transform _target)
    {
        target = _target;
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject effect = (GameObject)Instantiate(damage_effect, transform.position, transform.rotation);
        Destroy(effect, 1f);

        //Destroy(col.gameObject);
        if(col != null)
        { 
            if(col.gameObject.tag == "Enemy")
            { 
                enemy_script = col.GetComponent<enemy>();
                enemy_script.ReceiveDamage(damage);
                Destroy(gameObject);
            }

            if (col.gameObject.tag == "Enemy2")
            {
                enemy_script2 = col.GetComponent<enemy2>();
                enemy_script2.ReceiveDamage(damage);
                Destroy(gameObject);
            }
        }

    }
	
	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float current_distance = speed * Time.deltaTime;

        

        transform.Translate(dir.normalized * current_distance, Space.World);
	}
}
