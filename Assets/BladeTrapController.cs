using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrapController : MonoBehaviour
{
    BladeController blade0;
    BladeController blade1;
    // Start is called before the first frame update
    void Start()
    {
        blade0 = transform.GetChild(0).GetComponent<BladeController>();
        blade1 = transform.GetChild(1).GetComponent<BladeController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("player"))
        {
            //blade0.Move();
            //blade1.Move();
        }
    }
}
