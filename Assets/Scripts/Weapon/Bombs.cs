using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : Weapon
{
    public float attacking_distance = 0.003f;
    public GameObject cloud_prefab;
    GameObject[] enemies;

    public void Attack()
    {
        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        Vector3[] cloud_position;
        //wait for seconds
        yield return new WaitForSeconds(0.5f);
        //begin to attack and damage enemies
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        cloud_position = new Vector3[]{new Vector3(0,0,0), new Vector3(0.6f,0,0), new Vector3(-0.6f,0,0), new Vector3(0.3f,0.5f,0), new Vector3(0.3f,-0.5f,0), new Vector3(-0.3f,0.5f,0), new Vector3(-0.3f,-0.5f,0)};
        for(int i=0;i<7;i++)
        {
            Instantiate(cloud_prefab, transform.position+cloud_position[i], Quaternion.identity);
        }

        foreach(GameObject enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position,transform.position)<attacking_distance)
            {
                EnemyInteraction enemyInteraction = enemy.GetComponent<EnemyInteraction>();
                if (enemyInteraction != null) enemyInteraction.getHit(GameObject.Find("Player"), damage);
            }
        }
        Destroy(gameObject);
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
