using UnityEngine;

public class SpikeTrap : MonoBehaviour {

    public int damage = 5;
    public int durability = 10;
    public GameObject damage_effect;
    public enemy enemy_script;
    public enemy2 enemy_script2;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GameObject effect = (GameObject)Instantiate(damage_effect, transform.position, transform.rotation);
            Destroy(effect, 1f);


            enemy_script = col.GetComponent<enemy>();
            enemy_script.ReceiveDamage(damage);

            durability--;
            if(durability <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.gameObject.tag == "Enemy2")
        {
            GameObject effect = (GameObject)Instantiate(damage_effect, transform.position, transform.rotation);
            Destroy(effect, 1f);


            enemy_script2 = col.GetComponent<enemy2>();
            enemy_script2.ReceiveDamage(damage);

            durability--;
            if (durability <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }





}
