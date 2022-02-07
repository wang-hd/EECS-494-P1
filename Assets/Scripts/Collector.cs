using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip rupee_collection_sound_clip;
    public AudioClip health_collection_sound_clip;
    public AudioClip bomb_collection_sound_clip;
    public AudioClip keyCollectSound;

    Inventory inventory;
    HasHealth player_health;
    AudioSource low_health;
    bool is_play_music = false;

    void Start()
    {
        low_health = GetComponent<AudioSource>();
        low_health.Stop();
        inventory = GetComponent<Inventory>();
        player_health = GetComponent<HasHealth>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collider has no inventory to store things in!");
        }
    }

    void Update()
    {
        if(!is_play_music&&player_health.get_health()<=1)
        {
            low_health.Play();
            is_play_music = true;
        }else if(is_play_music&&player_health.get_health()>1)
        {
            low_health.Stop();
            is_play_music = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collide_with = coll.gameObject;

        if (object_collide_with.tag == "rupee")
        {
            if (inventory != null)
                inventory.add_rupees(1);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (rupee_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "health")
        {
            player_health.add_health(2);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (health_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "bomb")
        {
            if (inventory != null)
            {
                if (!inventory.bomb_acquired)
                {
                    inventory.add_bomb_weapon();
                    inventory.bomb_acquired = true;
                }
                inventory.add_bombs(4);
            }

            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (bomb_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "key")
        {
            if (inventory != null) inventory.add_keys(1);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint(keyCollectSound, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "bow")
        {
            if (inventory != null) inventory.add_bow();
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint(keyCollectSound, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "boomerang")
        {
            if (inventory != null) inventory.add_boomerang();
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint(bomb_collection_sound_clip, Camera.main.transform.position);
        }
    }
}
