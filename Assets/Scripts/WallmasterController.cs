using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallmasterController : EnemyMovement
{
    GameObject player;
    PlayerMovement playerControl;
    int motion = 0;
    bool grabPlayer = false;
    Vector3 originalPosition;
    Vector3 targetPosition;
    Vector3 collisionPosition;
    Vector3 referenceVector;
    // Start is called before the first frame update
    public override void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
        
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerMovement>();
        
        collisionPosition = player.transform.position;
        referenceVector = collisionPosition - originalPosition;
    }

    // Update is called once per frame
    public override void Update()
    {
        SetNewDestination();
        MoveTowardsDestination();
        if (grabPlayer)
        {
            player.transform.position = transform.position;
            PlayerInteraction.setPlayerInvincible(true);
        }
    }

    public override void SetNewDestination()
    {
        if (transform.position == targetPosition)
        {
            if (motion == 0)
            {
                motion = 1;
                calculateTargetPosition();
            }
            else if (motion == 1)
            {
                motion = 2;
                calculateTargetPosition();
            }
            else if (motion == 2)
            {
                motion = 3;
                calculateTargetPosition();
            }
            else if (motion == 3)
            {
                motion = 0;
                if (grabPlayer)
                {
                    grabPlayer = false;
                    PlayerInteraction.setPlayerInvincible(false);
                    Camera.main.transform.position = GameController.init_camera_pos;
                    player.transform.position = new Vector3 (39.5f, 2f, 0);
                    Destroy(gameObject);
                }
                
            }
        }
    }

    void calculateTargetPosition()
    {   
        if (Mathf.Abs(referenceVector.x) <= Mathf.Abs(referenceVector.y))
        {
            if (motion == 1) targetPosition.x += referenceVector.x;
            else if (motion == 2) targetPosition.y += referenceVector.y;
            else targetPosition.x -= referenceVector.x;
        }
        else
        {
            if (motion == 1) targetPosition.y += referenceVector.y;
            else if (motion == 2) targetPosition.x += referenceVector.x;
            else targetPosition.y -= referenceVector.y;
        }
    }

    public override void MoveTowardsDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public override void OnDisable()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("player"))
        {
            playerControl.enabled = false;
            grabPlayer = true;
        }
    }

}
