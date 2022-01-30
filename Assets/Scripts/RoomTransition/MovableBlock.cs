using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{
    protected bool is_collision = false;
    protected bool is_key_down = false;
    protected bool could_move = true;
    protected int direction=-1;
    protected int layer = 1<<6;
    protected float startCollisionTime = 0f;
    protected float startKeyDownTime = 0f;
    protected float holdTime = 1.0f;
    protected Camera cam;
    protected Vector3 ori_pos;

    protected virtual void Start()
    {
        cam = Camera.main;
        ori_pos=transform.position;
    }

    protected virtual void Update()
    {
        if(!CoroutineUtilities.InCurrentRoom(transform.position, cam.transform.position))
        {
            transform.position = ori_pos;
            could_move = true;
        }
    }
    protected void MoveBlock(int direction, Transform block)
    {
        switch(direction)
        {
            case 0:
              StartCoroutine(CoroutineUtilities.MoveObjectOverTime(block, block.position, block.position+new Vector3(0,-1,0), 0.4f));
              break;
            case 1:
              StartCoroutine(CoroutineUtilities.MoveObjectOverTime(block, block.position, block.position+new Vector3(-1,0,0), 0.4f));
              break;
            case 2:
              StartCoroutine(CoroutineUtilities.MoveObjectOverTime(block, block.position, block.position+new Vector3(0,1,0), 0.4f));
              break;
            case 3:
              StartCoroutine(CoroutineUtilities.MoveObjectOverTime(block, block.position, block.position+new Vector3(1,0,0), 0.4f));
              break;
            default:
              break;
        }
    }


}
