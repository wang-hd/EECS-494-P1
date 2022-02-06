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
        key_is_taken = new List<bool>() {false, false, false, false};

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

        currentRoom.x = 1 + (roomX - init_camera_pos.x) / room_length;
        currentRoom.y = 0 + (roomY - init_camera_pos.y) / room_height;
    }

    void checkVisitedRooms()
    {
        
        if (currentRoom == new Vector2 (1, 0))
        {
            // initial room
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_1_0.Add(Instantiate(stalfo, new Vector3(10, 5, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_1_0) && !key_is_taken[0])
            {
                SpawnKey(new Vector3 (10, 6, 0), 0);
            }
        }
        else if (currentRoom == new Vector2 (2, 0))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                enemy_2_0.Add( Instantiate(stalfo, new Vector3 (28, 7, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_2_0) && !key_is_taken[1])
            {
                SpawnKey(new Vector3 (27, 5, 0), 1);
            }
        }
        else if (currentRoom == new Vector2(3, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_3_0.Add(Instantiate(stalfo, new Vector3(40, 3, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_3_0) && !key_is_taken[2])
            {
                SpawnKey(new Vector3(38, 7, 0), 2);
            }
        }
        else if (currentRoom == new Vector2(4, 0))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                enemy_4_0.Add(Instantiate(stalfo, new Vector3(53, 7, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_4_0) && !key_is_taken[3])
            {
                SpawnKey(new Vector3(60, 6, 0), 3);
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
