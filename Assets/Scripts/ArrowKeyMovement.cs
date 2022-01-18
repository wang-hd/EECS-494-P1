using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{

    public float Movement_speed = 4;
    public static bool player_control = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_control)
        {
            Vector2 current_input = GetInput();
            rb.velocity = current_input * Movement_speed;
        }
    }

    private Vector2 GetInput() 
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horizontal_input) > 0.0f) {
            vertical_input = 0.0f;
        }

        return new Vector2(horizontal_input, vertical_input);
    }

    public void SetPlayerControl(bool value)
    {
        player_control = value;
    }
    public bool GetPlayerControl()
    {
        return player_control;
    }
}
