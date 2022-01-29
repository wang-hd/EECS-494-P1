using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaAttack : EnemyAttack
{
    public bool returned = false;
    public GameObject boomerang_prefab;
    public override IEnumerator DoAttack()
    {
        enemyMovement.enabled = false;

        GameObject boomerang = Instantiate(boomerang_prefab, transform.position, Quaternion.identity);
        boomerang.GetComponent<GoriyaBoomerang>().SetParentGoriya(gameObject);
        
        while (!returned)
        {
            yield return new WaitForSeconds(0.1f);
        }

        enemyMovement.enabled = true;
        returned = false;
    }
}
