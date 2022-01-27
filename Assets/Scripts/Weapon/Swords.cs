using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is an inheritance of weapon class, which is for swords.
public class Swords : Weapon
{
    int sword_projectiles = 0;
    bool is_projectile=false;
    Vector3 init_camera_pos;
    int direction = 0;

    void Awake()
    {
        // This command will be called for many times when it is in the Start()
        GetComponent<Projectile>().enabled = false;
    }

    void Start()
    {
        if(is_projectile)
        {
            PlayerAttack.sword_projectiles++;
            sword_projectiles = PlayerAttack.sword_projectiles;
            init_camera_pos = Camera.main.transform.position;
        }else
        {
          direction = PlayerMovement.direction;
          GetComponent<Animator>().SetInteger("direction", direction);
        }
    }

    void OnDestroy()
    {
        if(is_projectile)
        {
            PlayerAttack.sword_projectiles--;
        }

    }

    void Update()
    {
        if (is_projectile&&!CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            transform.position = Vector3.zero;
            if (sword_projectiles > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// This function is used when the swords are needed to become a projectile
    /// </summary>
    public override void setProjectile()
    {
      is_projectile = true;
      GetComponent<Projectile>().enabled = true;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (is_projectile&&other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
