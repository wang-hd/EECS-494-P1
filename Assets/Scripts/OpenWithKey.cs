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
            Debug.Log("Player has " + playerInventory.keys + " keys");
            if (playerInventory != null && playerInventory.keys > 0) {
                playerInventory.keys--;
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(doorOpenSound, Camera.main.transform.position);
            }
        }
    }
}
