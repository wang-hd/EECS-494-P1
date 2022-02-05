using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasLoot : MonoBehaviour
{
    public GameObject loot;
    HasHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HasHealth>();
    }

    // Update is called once per frame
    private void OnDestroy() 
    {
        Instantiate(loot, transform.position, Quaternion.identity);
    }
}
