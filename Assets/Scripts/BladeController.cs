using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public int rayDirectionInt1;
    public Vector3 destination1;
    public int rayDirectionInt2;
    public Vector3 destination2;
    Vector3 destination;
    float attackSpeed = 5f;
    float returnSpeed = 2f;
    Vector2 rayDirection1;
    Vector2 rayDirection2;
    int layerMask = 1 << 6; // set the layer mask to detct only layer 6 (player)
    int motion = 0; // set the movement of blade
    Vector3 originalPosition;
    readonly Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    void Start() {
        originalPosition = transform.position;
        if (PlayerMovement.isCustomLevel) 
        {
            layerMask = 1 << 6 | 1 << 11;
            attackSpeed = 10f;
            returnSpeed = 1f;
        }
    }

    // Update is called once per frame
    void Update()
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
            if (PlayerMovement.isCustomLevel) gameObject.GetComponent<BoxCollider>().enabled = false;
            Move(originalPosition, returnSpeed);
        }
        if (transform.position == destination)
        {
            motion = 2;
            StartCoroutine(Wait());
        }
        else if (transform.position == originalPosition)
        {
            if (PlayerMovement.isCustomLevel) gameObject.GetComponent<BoxCollider>().enabled = true;
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
        rayDirection1 = directions[rayDirectionInt1];
        rayDirection2 = directions[rayDirectionInt2];
        RaycastHit hit1;
        RaycastHit hit2;
        Ray ray1 = new Ray (transform.position, rayDirection1);
        Ray ray2 = new Ray (transform.position, rayDirection2);
        if (Physics.Raycast(ray1, out hit1, 10f, layerMask))
        {
            if (hit1.collider.gameObject.CompareTag("player") || hit1.collider.gameObject.CompareTag("weapon"))
            {
                destination = destination1;
                motion = 1;
            }
        }
        else if (!PlayerMovement.isCustomLevel && Physics.Raycast(ray2, out hit2, 10f, layerMask))
        {
            if (hit2.collider.gameObject.CompareTag("player"))
            {
                destination = destination2;
                motion = 1;
            }
        }
    }

    public int GetMotion()
    {
        return motion;
    }
}
