using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is an inheritance of weapon class, which is for swords.
public class Swords : Weapon
{
    public GameObject effect_1;
    public GameObject effect_2;
    public GameObject effect_3;
    public GameObject effect_4;
    public AudioClip sword_projectile_sound_clip;
    Vector3 init_camera_pos;

    void Start()
    {
        PlayerAttack.sword_projectiles++;
        init_camera_pos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint (sword_projectile_sound_clip, Camera.main.transform.position);
    }

    void OnDestroy()
    {
        PlayerAttack.sword_projectiles--;
    }

    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            MakeAnimate();
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("enemy") || other.CompareTag("projectilehit"))
        {
            MakeAnimate();
            Destroy(gameObject);
        }
    }

    void MakeAnimate()
    {
        Instantiate(effect_1, transform.position, Quaternion.identity);
        Instantiate(effect_2, transform.position, Quaternion.identity);
        Instantiate(effect_3, transform.position, Quaternion.identity);
        Instantiate(effect_4, transform.position, Quaternion.identity);
    }
}
