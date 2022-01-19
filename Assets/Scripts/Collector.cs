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

    void Start() 
    {
        inventory = GetComponent<Inventory>();
        player_health = GetComponent<HasHealth>();
        if (inventory == null) {
            Debug.LogWarning("WARNING: Gameobject with a collider has no inventory to store things in!");
        }
    }

    void OnTriggerEnter(Collider coll) 
    {
        GameObject object_collide_with = coll.gameObject;
        
        if (object_collide_with.tag == "rupee")
        {
            if (inventory != null)
                inventory.Add_rupees(1);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (rupee_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "health")
        {
            player_health.Add_health(1.0f);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (health_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "bomb")
        {
            if (inventory != null)
                inventory.Add_bombs(1);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint (bomb_collection_sound_clip, Camera.main.transform.position);
        }
        else if (object_collide_with.tag == "key")
        {
            if (inventory != null) inventory.add_keys(1);
            Destroy(object_collide_with);

            AudioSource.PlayClipAtPoint(keyCollectSound, Camera.main.transform.position);
        }
    }
}
