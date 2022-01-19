using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWithKey : MonoBehaviour
{
    public AudioClip doorOpenSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Player hit locked door");
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null && playerInventory.get_keys() > 0) {
                if (!Inventory.god_mode) playerInventory.add_keys(-1);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(doorOpenSound, Camera.main.transform.position);
            }
        }
    }
}
