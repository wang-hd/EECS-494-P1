using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusSound : MonoBehaviour
{
    AudioSource audioSource;
    Vector3 init_camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_camera_pos = Camera.main.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}
