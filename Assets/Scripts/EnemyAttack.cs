using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    public int threshold = 1; // if we don't need an explicit attack animation, set to 0
    EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) < threshold && enemyMovement.enabled)
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        enemyMovement.enabled = false;
        // do some attack e.g. throw a boomerang
        // placeholder: stop for one second
        yield return new WaitForSeconds(1f);
        enemyMovement.enabled = true;
    }
}
