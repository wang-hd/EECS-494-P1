using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TunnelRoom : RoomTransition
{

    Image filter;

    readonly Vector3 cameraDown = new Vector3(0,-1,17.5f);
    readonly Vector3 cameraUp = new Vector3(0,1,-17.5f);

    readonly Vector3 playerDown = new Vector3(18, 62, 12);
    readonly Vector3 playerUp = new Vector3(21,60,0);

    protected override void Start()
    {
        base.Start();
        if(GameObject.Find("BlackFilter")!=null)
        {
            filter = GameObject.Find("BlackFilter").GetComponent<Image>();
        }
        else
        {
            Debug.Log("[TunnelRoom] Could not find BlackFilter");
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (player_control.enabled)
            {
                Debug.Log("Do transition");
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;

                if (this.CompareTag("UpDoor"))
                {
                    StartCoroutine(CameraTurnBlack());
                    StartCoroutine(CoroutineUtilities.MoveObjectOverTime(player.transform, player.transform.position, playerUp, 0.4f));
                    StartCoroutine(base.CameraRoomTransition(cameraUp));
                    cam.orthographicSize=7.5f;
                }
                else if (this.CompareTag("DownDoor"))
                {
                    StartCoroutine(CameraTurnBlack());
                    StartCoroutine(CoroutineUtilities.MoveObjectOverTime(player.transform, player.transform.position, playerDown, 0.4f));
                    StartCoroutine(base.CameraRoomTransition(cameraDown));
                    cam.orthographicSize=9f;
                }
            }
            else
            {
                Debug.Log("Transition already happening, don't do anything");
            }
        }
    }

    IEnumerator CameraTurnBlack()
    {
        filter.color=new Color(0,0,0,255);
        yield return new WaitForSeconds(3f);
        filter.color=new Color(0,0,0,0);
    }
}
