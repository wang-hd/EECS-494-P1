using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    public int threshold = 1; // if we don't have an explicit attack, set to 0
    protected EnemyMovement enemyMovement;
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
            attack();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.gameObject.GetComponent<PlayerInteraction>().getHit(gameObject);
        }
    }

    void OnCollisionEnter(Collision other) {
        GameObject object_collider_with = other.gameObject;
        if (object_collider_with.CompareTag("player"))
        {
            other.gameObject.GetComponent<PlayerInteraction>().getHit(gameObject);
        }
        if (GetComponent<EnemyGridMovement>() != null) GetComponent<EnemyGridMovement>().grid.AdjustToNearestTile();
    }

    void attack()
    {
        StartCoroutine(DoAttack());
    }

    public virtual IEnumerator DoAttack()
    {
        yield return null;
    }
}
