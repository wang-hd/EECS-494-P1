using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    // TODO: REFACTOR TO WORK WITH ENEMIES AS WELL
    public static readonly int up = 0;
    public static readonly int right = 1;
    public static readonly int down = 2;
    public static readonly int left = 3;

    // When collider with an object, the player will adjust to the nearest half-tile
    public void AdjustPosition(int curr_direction)
    {
        // original position of player
        float horizontal_position = transform.position.x;
        float vertical_position = transform.position.y;

        // if collider with an object horizontally, adjust player to nearest vertical half-tile
        if (curr_direction == left || curr_direction == right)
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
        
        if (curr_direction == up || curr_direction == down)
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
