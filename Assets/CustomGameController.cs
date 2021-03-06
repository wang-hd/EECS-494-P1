using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameController : MonoBehaviour
{
   public static float room_length = 16f;
    public static float room_height = 11f;
    public static Vector3 init_camera_pos;
    public Camera cam;
    public GameObject keese;
    public GameObject stalfo;
    public GameObject stalfo_with_key;
    public GameObject stalfo_for_trap;
    public GameObject stalfo_can_be_pushed;
    public GameObject stalfo_can_only_be_pushed;
    public GameObject gel;
    public GameObject goriya;
    public GameObject Aquamentus;
    public GameObject key;
    public GameObject lockDoor;
    public static GameObject pushableBlock;
    public AudioClip boomerangSpawnSound;
    public GameObject boomerang;


    static Vector3 initial_block_position;
    static List<GameObject> enemy_1_0 = new List<GameObject>();
    static List<GameObject> enemy_2_0 = new List<GameObject>();
    static List<GameObject> enemy_3_0 = new List<GameObject>();
    static List<GameObject> enemy_4_0 = new List<GameObject>();
    static List<GameObject> enemy_2_1 = new List<GameObject>();

    static List<bool> key_is_taken;
    Vector2 currentRoom = new Vector2 (1, 0);
    HashSet<Vector2> visitedRooms = new HashSet<Vector2>();

    public AudioClip doorCloseSound;
    public AudioClip keySpawnSound;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        init_camera_pos = cam.transform.position;
        key_is_taken = new List<bool>() {false, false, false, false, false};

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

        currentRoom.x = 0 + (roomX - init_camera_pos.x) / room_length;
        currentRoom.y = 0 + (roomY - init_camera_pos.y) / room_height;
    }

    void checkVisitedRooms()
    {
        if (currentRoom == new Vector2 (0, 0))
        {
            // initial room
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);

            }
        }
        else if (currentRoom == new Vector2 (1, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_1_0.Add(Instantiate(gel, new Vector3(26, 5, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_1_0) && !key_is_taken[0])
            {
                SpawnKey(new Vector3 (26, 6, 0), 0);
            }
        }
        else if (currentRoom == new Vector2 (2, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_2_0.Add( Instantiate(stalfo, new Vector3 (44, 7, 0), Quaternion.identity));
                enemy_2_0.Add(Instantiate(gel, new Vector3(38, 6, 0), Quaternion.identity));
                enemy_2_0.Add(Instantiate(stalfo, new Vector3(41, 2, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_2_0) && !key_is_taken[1])
            {
                SpawnKey(new Vector3 (43, 5, 0), 1);
            }
        }
        else if (currentRoom == new Vector2(3, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_3_0.Add(Instantiate(gel, new Vector3(56, 3, 0), Quaternion.identity));
                enemy_3_0.Add(Instantiate(stalfo, new Vector3(53, 7, 0), Quaternion.identity));
                enemy_3_0.Add(Instantiate(goriya, new Vector3(60, 6, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_3_0) && !key_is_taken[2])
            {
                SpawnKey(new Vector3(54, 7, 0), 2);
            }
        }
        else if (currentRoom == new Vector2(4, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_4_0.Add(Instantiate(stalfo, new Vector3(73, 8, 0), Quaternion.identity));
                enemy_4_0.Add(Instantiate(stalfo, new Vector3(73, 7, 0), Quaternion.identity));
                enemy_4_0.Add(Instantiate(goriya, new Vector3(75, 6, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_4_0) && !key_is_taken[3])
            {
                SpawnKey(new Vector3(76, 6, 0), 3);
            }
        }
        else if (currentRoom == new Vector2(5, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo, new Vector3(92, 2, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3(88, 3, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3(85, 4, 0), Quaternion.identity);
                Instantiate(stalfo, new Vector3(83, 2, 0), Quaternion.identity);
                Instantiate(goriya, new Vector3(87, 8, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2(4, 1))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                Instantiate(key, new Vector3(71.5f, 19, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2(3, 1))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                Instantiate(key, new Vector3(55, 16, 0), Quaternion.identity);
            }

        }
        else if (currentRoom == new Vector2(2, 1))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_2_1.Add(Instantiate(stalfo_can_only_be_pushed, new Vector3(39, 13, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_2_1) && !key_is_taken[4])
            {
                SpawnKey(new Vector3(40, 16, 0), 4);
            }
        }
        else if (currentRoom == new Vector2(1, 1))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                Instantiate(stalfo_can_be_pushed, new Vector3(20, 16, 0), Quaternion.identity);
            }
        }
    }

    static bool isEmptyList(List<GameObject> list)
    {
        foreach (GameObject enemy in list)
        {
            if (enemy != null) return false;
        }
        return true;
    }

    public static bool isEnemyCleared(int roomNumber)
    {
        if (roomNumber == 1) return isEmptyList(enemy_2_0);
        return false;
    }
    public static bool RequirementAchieved(int roomNumber)
    {
        if (roomNumber == 1) return true;
        return false;
    }


    void SpawnKey(Vector3 position, int roomNumber)
    {
        Instantiate(key, position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(keySpawnSound, Camera.main.transform.position);
        key_is_taken[roomNumber] = true;
    }

}
