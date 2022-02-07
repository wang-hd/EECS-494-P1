using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLeaf : MonoBehaviour
{
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("player"))
        {
            PlayerMovement.getLeaf = true;
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
