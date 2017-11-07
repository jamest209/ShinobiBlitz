using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLauncher : MonoBehaviour {

    public Transform target;
    public float range = 10f;
    public Transform rotation_part;
    public float rotation_speed = 5f;

    public float fire_rate = 2f;
    private float fire_countdown = 0f;

    public GameObject bullet_prefab;
    public Transform spawn_point;


    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bullet_prefab, spawn_point.position, spawn_point.rotation);
        shuriken bullet_script = bulletGO.GetComponent<shuriken>();

        if (bullet_script != null)
        {
            bullet_script.Chase(target);
        }
    }




    void Update()
    {
        if (target == null)
            return;

        if (fire_countdown <= 0f)
        {
            Shoot();
            fire_countdown = 1f / fire_rate;
        }

        fire_countdown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
