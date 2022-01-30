using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnRoomExit : MonoBehaviour
{
    //public Vector3 init_camera_pos;
    EnemyMovement enemyMovement;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        sprite = GetComponent<SpriteRenderer>();
        //init_camera_pos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineUtilities.InCurrentRoom(transform.position, GameController.init_camera_pos))
        {
            if (!sprite.enabled)
            {
                if (enemyMovement != null) enemyMovement.enabled = true;
            }
            sprite.enabled = true;
        }
        else
        {
            if (sprite.enabled)
            {
                if (enemyMovement != null) enemyMovement.enabled = false;
            }
            sprite.enabled = false;
        }
    }
}
