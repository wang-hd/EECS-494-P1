using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    // TODO: REFACTOR TO WORK WITH ENEMIES AS WELL
    
    // When collider with an object, the player will adjust to the nearest half-tile
    private void Update()
    {
        // original position of player
        float horizontal_position = transform.position.x;
        float vertical_position = transform.position.y;

        // if collider with an object horizontally, adjust player to nearest vertical half-tile
        if (Input.GetAxisRaw("Horizontal")!=0.0f)
        {
            float deviation_with_tile = vertical_position % 1f;
            float new_vertical_position = vertical_position;
            if (Mathf.Abs(deviation_with_tile) < 0.25f)
            {
                new_vertical_position = vertical_position - deviation_with_tile;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.75f)
            {
                new_vertical_position = vertical_position - deviation_with_tile + 0.5f * vertical_position / Mathf.Abs(vertical_position);
            }
            else
            {
                new_vertical_position = vertical_position - deviation_with_tile + 1f * vertical_position / Mathf.Abs(vertical_position);
            }
            transform.position = new Vector2(horizontal_position, new_vertical_position);
        }

        if (Input.GetAxisRaw("Vertical")!=0.0f)
        {
            float deviation_with_tile = horizontal_position % 1f;
            float new_horizontal_position = horizontal_position;
            if (Mathf.Abs(deviation_with_tile) < 0.25f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.75f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 0.5f * horizontal_position / Mathf.Abs(horizontal_position);
            }
            else
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 1f * horizontal_position / Mathf.Abs(horizontal_position);
            }
            transform.position = new Vector2(new_horizontal_position, vertical_position);
        }
    }
}
