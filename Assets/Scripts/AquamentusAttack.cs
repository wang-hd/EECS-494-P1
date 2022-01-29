using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusAttack : MonoBehaviour
{
    public GameObject fireball_prefab;
    Animator animator;
    float attack_cooldown = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackPeriodically(attack_cooldown));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackPeriodically(float interval)
    {
        while (true)
        {
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(0.4f);
            for (int i = -1; i < 2; i++)
            {
                GameObject fireball = Instantiate(fireball_prefab, transform.position + Vector3.up * (0.5f + i * 0.25f), Quaternion.identity);
                fireball.GetComponent<FireballMovement>().SetDestination(Camera.main.transform.position, GameObject.Find("Player").transform.position, i);
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
