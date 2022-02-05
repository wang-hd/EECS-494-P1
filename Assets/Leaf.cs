using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Weapon
{
    GameObject player;
    Vector3 init_camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttack.leaf_projectiles++;
        init_camera_pos = Camera.main.transform.position;
        damage = 0;
        player = GameObject.Find("Player");
    }

    void OnDestroy()
    {
        PlayerAttack.leaf_projectiles--;
    }

    // Update is called once per frame
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
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
