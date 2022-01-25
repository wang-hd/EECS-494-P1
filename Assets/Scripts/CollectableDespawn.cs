using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDespawn : MonoBehaviour
{
    public int lifetime = 10;
    public bool despawnOnExit = false;
    Vector3 init_camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        init_camera_pos = Camera.main.transform.position;
        StartCoroutine(Lifespan());
    }

    // Update is called once per frame
    void Update()
    {
        if (!CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            if (despawnOnExit)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Lifespan()
    {
        if (CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            yield return new WaitForSeconds(1);
            lifetime -= 1;

            if (lifetime == 0) Destroy(gameObject);
        }
    }
}
