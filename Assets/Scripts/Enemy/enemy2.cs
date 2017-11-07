using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {
    public float movement_speed = 5f; //the movement speed of this enemy
    [HideInInspector]
    public float start_speed;
    public int health = 15; //health of the enemy
    public int reward = 25; //reward for killing the enemy.
    public int health_boost = 3;
    public bool slowed = false;
    public float slow_timer = 3f;
    private float current_slow_timer = 0f;
    public bool frozen = false;
    private float current_frozen_timer = 0f;

    private Transform target; //the target destination of where the ai is going to move.
    private int wavepointIndex = 0; //keeps track of the current waypoint to increment to next waypoint.

    // Use this for initialization
    void Start()
    {
        target = waypoints2.points[0];
        start_speed = movement_speed;
    }

    public void ReceiveDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            PlayerStats.money += reward;
            wavespawner.enemy_remaining--;
            Destroy(this.gameObject);
        }
    }

    public void SlowDown()
    {
        movement_speed = movement_speed / 2;
        slowed = true;
        current_slow_timer = slow_timer;
    }

    public void Freeze(float frozen_timer)
    {
        movement_speed = 0;
        frozen = true;
        current_frozen_timer = frozen_timer;
    }

    public void IncreaseHealth(int wave_number)
    {
        health += health_boost * wave_number;
    }

    void NextWaypoint()
    {
        if (wavepointIndex >= waypoints2.points.Length - 1)
        {
            PlayerStats.lose_life();
            wavespawner.enemy_remaining--;
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = waypoints2.points[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position; //get the direction of target by subtracting the target's position with this position.

        transform.Translate(dir.normalized * movement_speed * Time.deltaTime); //move to the target destination

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) //if the enemy made it to the waypoint, move to next one.
        {
            NextWaypoint();
        }

        if(slowed)
        {
            current_slow_timer -= Time.deltaTime;
            if(current_slow_timer <= 0f)
            {
                slowed = false;
                movement_speed = movement_speed * 2;
            }
        }

        if (frozen)
        {
            current_frozen_timer -= Time.deltaTime;
            if (current_frozen_timer <= 0f)
            {
                frozen = false;
                movement_speed = start_speed;
            }
        }
    }
}
