using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
{
    public float direction_horizontal;
    public float direction_vertical;
    public float direction_speed;
    void Start()
    {
        transform.position = new Vector3(transform.position.x+direction_horizontal, transform.position.y+direction_vertical, transform.position.z);
        StartCoroutine(Shooting());
    }

    void Update()
    {
        transform.Translate(direction_horizontal*direction_speed, direction_vertical*direction_speed, 0);
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

}
