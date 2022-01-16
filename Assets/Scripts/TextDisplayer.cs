using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    public Inventory inventory;
    Text text_component;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "HealthText")
        {
            text_component.text = "Health:" + inventory.Get_health().ToString();
        }
        
        if (gameObject.name == "RupeeText")
        {
            if (inventory != null && text_component != null) {
                text_component.text = "Rupees: " + inventory.Get_rupees().ToString();
            }
        }
    }
}
