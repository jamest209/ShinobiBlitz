using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrap : MonoBehaviour {

    public int durability = 3;
    public float duration = 1f;
    public enemy enemy_script;
    public enemy2 enemy_script2;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemy_script = col.GetComponent<enemy>();
            if(!enemy_script.frozen)
            {
                enemy_script.Freeze(duration);

                durability--;
                if (durability <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        if (col.gameObject.tag == "Enemy2")
        {
            enemy_script2 = col.GetComponent<enemy2>();
            if(!enemy_script2.frozen)
            {
                enemy_script2.Freeze(duration);

                durability--;
                if (durability <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
