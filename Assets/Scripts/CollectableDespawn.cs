using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDespawn : MonoBehaviour
{
    public int lifetime = 100; // lifetime in tenths of seconds
    public bool despawnOnExit = false;
    Vector3 init_camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_camera_pos = Camera.main.transform.position;
        StartCoroutine(Lifespan());
    }

    IEnumerator Lifespan()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
            {
                lifetime -= 1;
                if (lifetime == 0) Destroy(gameObject);
            }
            else
            {
                if (despawnOnExit) Destroy(gameObject);
            }
        }
    }
}
