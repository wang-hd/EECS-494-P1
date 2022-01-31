using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManBlock : MovableBlock
{
    //public GameObject locked_door;
    protected float distance = 1f;
    protected override void Start()
    {
        base.Start();
        //base.MoveBlock(0, transform);
      }
      // Update is called once per frame
    protected override void Update()
    {
        if(Physics.Raycast(transform.position, new Vector3(0,1,0), distance, layer))
        {
            if(!is_collision||direction!=0)
            {
                is_collision = true;
                startCollisionTime = Time.time;
                direction = 0;
            }
        }
        else if(Physics.Raycast(transform.position, new Vector3(0,-1,0), distance, layer))
        {
            if(!is_collision||direction!=2)
            {
                is_collision = true;
                startCollisionTime = Time.time;
                direction = 2;
            }
        }
        else if(Physics.Raycast(transform.position, new Vector3(1,0,0), distance, layer))
        {
            if(!is_collision||direction!=1)
            {
                is_collision = true;
                startCollisionTime = Time.time;
                direction = 1;
            }
        }
        else if(Physics.Raycast(transform.position, new Vector3(-1,0,0), distance, layer))
        {
            if(!is_collision||direction!=3)
            {
                is_collision = true;
                startCollisionTime = Time.time;
                direction = 3;
              }
        }
        else
        {
            is_collision = false;
        }
        if(is_collision&&(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)))
        {
            if(direction==0&&!is_key_down)
            {
                is_key_down = true;
                startKeyDownTime = Time.time;
            }
        }
        else if(is_collision&&(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)))
        {
            if(direction==2&&!is_key_down)
            {
                is_key_down = true;
                startKeyDownTime = Time.time;
            }
        }
        else if(is_collision&&(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)))
        {
            if(direction==1&&!is_key_down)
            {
                is_key_down = true;
                startKeyDownTime = Time.time;
            }
        }
        else if(is_collision&&(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)))
        {
            if(direction==3&&!is_key_down)
            {
                is_key_down = true;
                startKeyDownTime = Time.time;
            }
        }
        else
        {
              is_key_down = false;
        }
        if(is_collision&&is_key_down&&Time.time>startKeyDownTime+holdTime&&Time.time>startCollisionTime+holdTime&&could_move)
        {
            could_move = false;
            /*if(locked_door!=null)
            {
                Destroy(locked_door);
            }*/
            base.MoveBlock(direction, transform);
        }
        base.Update();
  }
}
