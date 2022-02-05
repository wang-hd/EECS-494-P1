using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is an inheritance of weapon class, which is for swords.
public class Swords : Weapon
{
    Vector3 init_camera_pos;

    void Start()
    {
        PlayerAttack.sword_projectiles++;
        init_camera_pos = Camera.main.transform.position;
    }

    void OnDestroy()
    {
        PlayerAttack.sword_projectiles--;
    }

    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("enemy") || other.CompareTag("projectilehit"))
        {
            Destroy(gameObject);
        }
    }
}
