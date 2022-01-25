using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is an inheritance of weapon class, which is for swords.
public class Swords : Weapon
{
    int sword_projectiles = 0;
    Vector3 init_camera_pos;

    void Start()
    {
        PlayerAttack.sword_projectiles++;
        sword_projectiles = PlayerAttack.sword_projectiles;
        init_camera_pos = Camera.main.transform.position;
    }

    void OnDestroy()
    {
        PlayerAttack.sword_projectiles--;
    }

    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            transform.position = Vector3.zero;
            if (sword_projectiles > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
