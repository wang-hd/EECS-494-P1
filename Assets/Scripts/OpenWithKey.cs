using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWithKey : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit locked door");
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory.keys > 0) {
                playerInventory.keys--;
                Destroy(this.gameObject);
            }
        }
    }
}
