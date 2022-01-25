using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    Inventory inventory;
    HasHealth player_health;
    Text text_component;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        player_health = GameObject.Find("Player").GetComponent<HasHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "HealthText")
        {
            text_component.text = "x " + player_health.get_health().ToString();
        }
        if (gameObject.name == "RupeeText")
        {
            if (inventory != null && text_component != null) {
                text_component.text = inventory.get_rupees().ToString();
            }
        }
        if (gameObject.name == "BombText")
        {
            if (inventory != null && text_component != null) {
                text_component.text = inventory.get_bombs().ToString();
            }
        }
        if (gameObject.name == "KeyText")
        {
            if (inventory != null && text_component != null) {
                text_component.text = inventory.get_keys().ToString();
            }
        }
    }
}
