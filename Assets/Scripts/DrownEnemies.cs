using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownEnemies : MonoBehaviour
{
    public AudioClip enemy_hit_sound;
    public AudioClip enemy_death_sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject other_gameObject = other.gameObject;
        if (other_gameObject.CompareTag("enemy"))
        {
            StartCoroutine(DrownEnemy(other_gameObject));
        }
    }

    IEnumerator DrownEnemy(GameObject enemy)
    {
        StartCoroutine(KeepEnemy(enemy));
        SpriteRenderer sprite = enemy.GetComponent<SpriteRenderer>();

        while (enemy != null && !enemy.GetComponent<HasHealth>().is_dead())
        {
            enemy.GetComponent<HasHealth>().lose_health(1);
            StartCoroutine(ChangeEnemyColor(sprite));
            AudioSource.PlayClipAtPoint(enemy_hit_sound, Camera.main.transform.position);
            yield return new WaitForSeconds(1f);
        }
        AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
        Destroy(enemy);
        yield return null;
    }

    IEnumerator KeepEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.GetComponent<EnemyMovement>().enabled = false;
            enemy.GetComponent<BoxCollider>().enabled = false;
            enemy.transform.position = transform.position;
            yield return null;
        }
    }

    IEnumerator ChangeEnemyColor(SpriteRenderer sprite)
    {
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1, 1, 1, 1);
    }
}
