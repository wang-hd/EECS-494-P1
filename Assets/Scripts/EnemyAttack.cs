using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator attack()
    {
        while (true)
        {
            if (Random.Range(0, 99) < 5)
            {
                enemyMovement.enabled = false;
                // do some attack e.g. throw a boomerang
                yield return new WaitForSeconds(0.5f);
                enemyMovement.enabled = true;
            } 
        }  
    }
}
