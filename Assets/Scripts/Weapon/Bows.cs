using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This is for the bow
public class Bows : Weapon
{
    public AudioClip arrow_attack_sound_clip;
    public AudioClip arrow_hit_sound_clip;
    Vector3 init_camera_pos;

    void Start()
    {
        PlayerAttack.bow_projectiles++;
        init_camera_pos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint (arrow_attack_sound_clip, Camera.main.transform.position);
    }

    void OnDestroy()
    {
        PlayerAttack.bow_projectiles--;
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
        if(other.CompareTag("enemy"))
        {
            AudioSource.PlayClipAtPoint (arrow_hit_sound_clip, Camera.main.transform.position);
        }
    }
}
