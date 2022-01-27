using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    public int threshold = 5;
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
            if (!gameObject.CompareTag("wallmaster") && Random.Range(0, 100) < threshold)
            {
                enemyMovement.enabled = false;
                // do some attack e.g. throw a boomerang
                yield return new WaitForSeconds(0.5f);
                enemyMovement.enabled = true;
            }
            yield return null;
        }  
    }
}
