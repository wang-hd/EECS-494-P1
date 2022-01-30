using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float room_length = 16f;
    public static float room_height = 11f;
    public static Vector3 init_camera_pos;
    public Camera cam;
    public GameObject keese;
    public GameObject stalfo;
    public GameObject gel;
    public GameObject goriya;
    public GameObject Aquamentus;
    Vector2 currentRoom = new Vector2 (2f, 0f);
    HashSet<Vector2> visitedRooms = new HashSet<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        init_camera_pos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        detectCurrentRoom();
        checkVisitedRooms();
    }

    void detectCurrentRoom()
    {
        float roomX = cam.transform.position.x;
        float roomY = cam.transform.position.y;

        currentRoom.x = 2 + (roomX - init_camera_pos.x) / room_length;
        currentRoom.y = 0 + (roomY - init_camera_pos.y) / room_height;
    }

    void checkVisitedRooms()
    {
        
        if (currentRoom == new Vector2 (2, 0))
        {
            // initial room
            if (!visitedRooms.Contains(currentRoom)) visitedRooms.Add(currentRoom);
        }
        else if (currentRoom == new Vector2 (1, 0))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(keese, new Vector3 (19, 6, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (23, 4, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (25, 5, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (3, 0))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3 (52, 7, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (52, 3, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (57, 5, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (60, 6, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (61, 2, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (2, 1))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3 (37, 19, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (35, 18, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (38, 15, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (1, 2))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3 (18, 27, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (19, 25, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (19, 29, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (21, 26, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (26, 30, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (26, 24, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (2, 2))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3 (37, 30, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (42, 30, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (44, 30, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (45, 28, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (43, 25, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (3, 2))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(keese, new Vector3 (53, 30, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (53, 24, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (58, 28, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (58, 26, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (60, 25, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (60, 29, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (61, 27, 0), Quaternion.identity);
                Instantiate(keese, new Vector3 (56, 28, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (1, 3))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(gel, new Vector3 (20, 39, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (22, 40, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (27, 40, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (2, 3))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(gel, new Vector3 (38, 38, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (43, 38, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (39, 40, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (43, 40, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (44, 41, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (3, 3))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(goriya, new Vector3 (52, 41, 0), Quaternion.identity);
                Instantiate(goriya, new Vector3 (53, 36, 0), Quaternion.identity);
                Instantiate(goriya, new Vector3 (61, 38, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (2, 4))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3 (35, 49, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (41, 51, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3 (44, 51, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (2, 5))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(goriya, new Vector3 (38, 63, 0), Quaternion.identity);
                Instantiate(goriya, new Vector3 (41, 63, 0), Quaternion.identity);
                Instantiate(goriya, new Vector3 (41, 61, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (4, 4))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                Instantiate(Aquamentus, new Vector3 (75, 49, 0), Quaternion.identity);
            }
        }
    }
}
