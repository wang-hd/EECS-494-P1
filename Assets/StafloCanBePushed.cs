using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StafloCanBePushed : MonoBehaviour
{
    bool isBeingPushed;
    GameObject bladetrap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() {
        if (isBeingPushed)
        {
            if (bladetrap != null && bladetrap.GetComponent<BladeController>() != null)
            {
                if (bladetrap.GetComponent<BladeController>().GetMotion() == 1)
                {
                    transform.position = bladetrap.transform.position;
                }
                else if (bladetrap.GetComponent<BladeController>().GetMotion() == 3)
                {
                    isBeingPushed = false;
                    bladetrap = null;
                }
            }
            
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("bladetrap"))
        {
            bladetrap = other.gameObject;
            if (bladetrap != null && bladetrap.GetComponent<BladeController>() != null
             && bladetrap.GetComponent<BladeController>().GetMotion() == 1)
            {
                isBeingPushed = true;
            }
        }
    }
}
