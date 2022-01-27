using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnRoomExit : MonoBehaviour
{
    public Vector3 init_camera_pos;
    Animator animator;
    EnemyMovement enemyMovement;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
        sprite = GetComponent<SpriteRenderer>();
        init_camera_pos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            animator.speed = 1;
            if (!sprite.enabled) enemyMovement.enabled = true;
            sprite.enabled = true;
        }
        else
        {
            animator.speed = 0;
            if (sprite.enabled) enemyMovement.enabled = false;
            sprite.enabled = false;
        }
    }
}
