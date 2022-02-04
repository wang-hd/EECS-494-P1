using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    public static readonly int up = 0;
    public static readonly int right = 1;
    public static readonly int down = 2;
    public static readonly int left = 3;
    public bool adjust = true;

    public void AdjustPosition(int curr_direction)
    {
        if (!adjust) return;

        // original position
        float horizontal_position = transform.position.x;
        float vertical_position = transform.position.y;

        // if the object is moving horizontally, adjust position to nearest vertical quarter-tile
        if (curr_direction == left || curr_direction == right)
        {
            float deviation_with_tile = vertical_position % 1f;
            float new_vertical_position = vertical_position;
            if (Mathf.Abs(deviation_with_tile) < 0.125f)
            {
                new_vertical_position = vertical_position - deviation_with_tile;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.375f)
            {
                new_vertical_position = vertical_position - deviation_with_tile + 0.25f;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.625f)
            {
                new_vertical_position = vertical_position - deviation_with_tile + 0.5f;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.875f)
            {
                new_vertical_position = vertical_position - deviation_with_tile + 0.5f;
            }
            else
            {
                new_vertical_position = vertical_position - deviation_with_tile + 1f;
            }
            transform.position = new Vector3(horizontal_position, new_vertical_position, transform.position.z);
        }

        if (curr_direction == up || curr_direction == down)
        {
            float deviation_with_tile = horizontal_position % 1f;
            float new_horizontal_position = horizontal_position;
            if (Mathf.Abs(deviation_with_tile) < 0.125f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.375f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 0.25f;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.625f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 0.5f;
            }
            else if (Mathf.Abs(deviation_with_tile) < 0.875f)
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 0.75f;
            }
            else
            {
                new_horizontal_position = horizontal_position - deviation_with_tile + 1f;
            }
            transform.position = new Vector3(new_horizontal_position, vertical_position, transform.position.z);
        }
    }
}
