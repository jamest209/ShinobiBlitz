using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilTrap : MonoBehaviour {

    public int durability = 3;
    public enemy enemy_script;
    public enemy2 enemy_script2;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemy_script = col.GetComponent<enemy>();
            enemy_script.SlowDown();

            durability--;
            if (durability <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.gameObject.tag == "Enemy2")
        {
            enemy_script2 = col.GetComponent<enemy2>();
            enemy_script2.SlowDown();

            durability--;
            if (durability <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
