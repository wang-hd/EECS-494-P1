using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This is for the bow 
public class Bows : Weapon
{
    int bow_projectiles = 0;
    Vector3 init_camera_pos;

    void Start()
    {
        PlayerAttack.bow_projectiles++;
        bow_projectiles = PlayerAttack.bow_projectiles;
        init_camera_pos = Camera.main.transform.position;
    }

    void OnDestroy()
    {
        PlayerAttack.bow_projectiles--;
    }

    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            transform.position = Vector3.zero;
            if (bow_projectiles > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
