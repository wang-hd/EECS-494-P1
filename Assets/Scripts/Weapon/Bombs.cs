using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : Weapon
{
    public float attacking_distance = 0.003f;
    public GameObject cloud_prefab;
    public bool collectable = true;
    GameObject[] enemies;

    public void Attack()
    {
        collectable = false;
        Debug.Log("[Bomb] Attack is ready to boom!");
        StartCoroutine(Boom());
        return;
    }

    IEnumerator Boom()
    {
        Vector3[] cloud_position;
        //wait for seconds
        yield return new WaitForSeconds(0.5f);
        //begin to attack and damage enemies
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log("[Bomb] enemy has been found, we are going to destroy the enemy!");
        Debug.Log("[Bomb] we are going to make clouds");
        cloud_position = new Vector3[]{new Vector3(0,0,0), new Vector3(0.6f,0,0), new Vector3(-0.6f,0,0), new Vector3(0.3f,0.5f,0), new Vector3(0.3f,-0.5f,0), new Vector3(-0.3f,0.5f,0), new Vector3(-0.3f,-0.5f,0)};
        for(int i=0;i<7;i++)
        {
            Instantiate(cloud_prefab, transform.position+cloud_position[i], Quaternion.identity);
        }

        foreach(GameObject enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position,transform.position)<attacking_distance)
            {
                Destroy(enemy);
            }
        }
        Destroy(gameObject);
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
