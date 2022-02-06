using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StafloForTrap : MonoBehaviour
{
    public AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("bladetrap"))
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
