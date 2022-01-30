using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{
    public bool bow_or_old;
    public GameObject door_key;

    bool is_collision = false;
    bool is_key_down = false;
    bool is_move = false;
    int direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("player"))
    //     {
    //
    //     }
    // }
}
