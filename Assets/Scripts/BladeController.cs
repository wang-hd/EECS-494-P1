using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : EnemyMovement
{
    public int rayDirectionInt;
    public Vector3 destination;
    float attackSpeed = 8f;
    float returnSpeed = 2f;
    Vector2 rayDirection;
    int layerMask = 1 << 6; // set the layer mask to detct only layer 6 (player)
    int motion = 0; // set the movement of blade
    Vector3 originalPosition;
    readonly Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    public override void Start() {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (motion == 0)
        {
            Detect();
        }
        
        if (motion == 1)
        {
            Move(destination, attackSpeed);
        }
        else if (motion == 3)
        {
            Move(originalPosition, returnSpeed);
        }
        if (transform.position == destination)
        {
            motion = 2;
            StartCoroutine(Wait());
        }
        else if (transform.position == originalPosition)
        {
            motion = 0;
        }
    }

    void Move(Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        motion = 3;
    }

    void Detect()
    {
        rayDirection = directions[rayDirectionInt];
        RaycastHit hit;
        Ray ray = new Ray (transform.position, rayDirection);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("player"))
            {
                motion = 1;
            }
        }
    }
}
