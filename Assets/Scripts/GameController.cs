using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
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
    static List<GameObject> enemy_1_2 = new List<GameObject>();
    static List<GameObject> enemy_1_3 = new List<GameObject>();
    static List<GameObject> enemy_2_2 = new List<GameObject>();
    static List<GameObject> enemy_2_4 = new List<GameObject>();
    static List<GameObject> enemy_2_5 = new List<GameObject>();
    static List<GameObject> enemy_4_4 = new List<GameObject>();
    static List<GameObject> enemy_3_3 = new List<GameObject>();
    static List<bool> key_is_taken;
    static bool boomerang_spawned = false;
    static Vector3 bowRoom = new Vector3(23.5f, 61, 7.5f);
    static bool bowRoomVisited = false;
    AudioSource aquamentusAudioSource;
    Vector2 currentRoom = new Vector2 (2f, 0f);
    HashSet<Vector2> visitedRooms = new HashSet<Vector2>();

    public AudioClip doorCloseSound;
    public AudioClip keySpawnSound;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        aquamentusAudioSource = GetComponent<AudioSource>();
        
        init_camera_pos = cam.transform.position;
        key_is_taken = new List<bool>() {false, false, false, false};

        pushableBlock = GameObject.Find("OldManRoomBlock");
        initial_block_position = pushableBlock.transform.position;
        pushableBlock.GetComponent<MovableBlock>().enabled = false;
        Debug.Log(initial_block_position.ToString());

        StartCoroutine(PlayAquamentusAudio());
    }

    // Update is called once per frame
    void Update()
    {
        detectCurrentRoom();
        checkVisitedRooms();
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene("custom level");
        }
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
        
        if (currentRoom == new Vector2 (2f, 0f))
        {
            // initial room
            if (!visitedRooms.Contains(currentRoom)) visitedRooms.Add(currentRoom);
        }
        else if (currentRoom == new Vector2 (1, 0))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                
                enemy_1_0.Add( Instantiate(keese, new Vector3 (19, 6, 0), Quaternion.identity));
                enemy_1_0.Add( Instantiate(keese, new Vector3 (23, 4, 0), Quaternion.identity));
                enemy_1_0.Add( Instantiate(keese, new Vector3 (25, 5, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_1_0) && !key_is_taken[0])
            {
                SpawnKey(new Vector3 (26, 2, 0), 0);
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
                Instantiate(stalfo_with_key, new Vector3 (61, 2, 0), Quaternion.identity);
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
                
                StartCoroutine(CoroutineUtilities.MoveObjectOverTime(player.transform, 
                new Vector3 (30, 27, 0), new Vector3 (29, 27, 0), 0.5f));
                Instantiate(lockDoor, new Vector3 (30, 27, 0), Quaternion.identity);
                AudioSource.PlayClipAtPoint(doorCloseSound, Camera.main.transform.position);

                enemy_1_2.Add( Instantiate(keese, new Vector3 (18, 27, 0), Quaternion.identity));
                enemy_1_2.Add( Instantiate(keese, new Vector3 (19, 25, 0), Quaternion.identity));
                enemy_1_2.Add( Instantiate(keese, new Vector3 (19, 29, 0), Quaternion.identity));
                enemy_1_2.Add( Instantiate(keese, new Vector3 (21, 26, 0), Quaternion.identity));
                enemy_1_2.Add( Instantiate(keese, new Vector3 (26, 30, 0), Quaternion.identity));
                enemy_1_2.Add( Instantiate(keese, new Vector3 (26, 24, 0), Quaternion.identity));
            }
        }
        else if (currentRoom == new Vector2 (2, 2))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                enemy_2_2.Add( Instantiate(stalfo, new Vector3 (37, 30, 0), Quaternion.identity));
                enemy_2_2.Add( Instantiate(stalfo, new Vector3 (42, 30, 0), Quaternion.identity));
                enemy_2_2.Add( Instantiate(stalfo, new Vector3 (44, 30, 0), Quaternion.identity));
                enemy_2_2.Add( Instantiate(stalfo, new Vector3 (45, 28, 0), Quaternion.identity));
                enemy_2_2.Add( Instantiate(stalfo, new Vector3 (43, 25, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_2_2) && !key_is_taken[1])
            {
                SpawnKey(new Vector3 (40, 29, 0), 1);
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
                enemy_1_3.Add( Instantiate(gel, new Vector3 (20, 39, 0), Quaternion.identity));
                enemy_1_3.Add( Instantiate(gel, new Vector3 (22, 40, 0), Quaternion.identity));
                enemy_1_3.Add( Instantiate(gel, new Vector3 (27, 40, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_1_3))
            {
                pushableBlock.GetComponent<MovableBlock>().enabled = true;
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
                Instantiate(gel, new Vector3 (43, 39, 0), Quaternion.identity);
                Instantiate(gel, new Vector3 (44, 41, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (3, 3))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                enemy_3_3.Add(Instantiate(goriya, new Vector3 (52, 41, 0), Quaternion.identity));
                enemy_3_3.Add(Instantiate(goriya, new Vector3 (53, 36, 0), Quaternion.identity));
                enemy_3_3.Add(Instantiate(goriya, new Vector3 (61, 38, 0), Quaternion.identity));
            }

            if (isEmptyList(enemy_3_3) && !boomerang_spawned)
            {
                Instantiate(boomerang, new Vector3(56, 40, 0), Quaternion.identity);
                boomerang_spawned = true;
                AudioSource.PlayClipAtPoint(boomerangSpawnSound, Camera.main.transform.position);
            }
        }
        else if (currentRoom == new Vector2 (2, 4))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                enemy_2_4.Add( Instantiate(stalfo_with_key, new Vector3 (35, 49, 0), Quaternion.identity));
                enemy_2_4.Add( Instantiate(stalfo, new Vector3 (41, 51, 0), Quaternion.identity));
                enemy_2_4.Add( Instantiate(stalfo, new Vector3 (44, 51, 0), Quaternion.identity));
            }
        }
        else if (currentRoom == new Vector2 (2, 5))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                enemy_2_5.Add( Instantiate(goriya, new Vector3 (38, 63, 0), Quaternion.identity));
                enemy_2_5.Add( Instantiate(goriya, new Vector3 (41, 63, 0), Quaternion.identity));
                enemy_2_5.Add( Instantiate(goriya, new Vector3 (41, 61, 0), Quaternion.identity));
            }
            if (isEmptyList(enemy_2_5) && !key_is_taken[3])
            {
                SpawnKey(new Vector3 (40, 62, 0), 3);
            }
        }
        else if (currentRoom == new Vector2(4, 3))
        {
            if (!visitedRooms.Contains(currentRoom))
            {
                visitedRooms.Add(currentRoom);
                Instantiate(key, new Vector3(74, 35, 0), Quaternion.identity);
            }
        }
        else if (currentRoom == new Vector2 (4, 4))
        {
            if (!visitedRooms.Contains(currentRoom)) 
            {
                visitedRooms.Add(currentRoom);
                
                Instantiate(lockDoor, new Vector3 (78, 49, 0), Quaternion.identity);
                AudioSource.PlayClipAtPoint(doorCloseSound, Camera.main.transform.position);
                
                enemy_4_4.Add( Instantiate(Aquamentus, new Vector3 (75, 49, 0), Quaternion.identity));

            }
        }
        else if (cam.transform.position == bowRoom)
        {
            if (!bowRoomVisited)
            {
                bowRoomVisited = true;
                Instantiate(keese, new Vector3(29, 59, 12), Quaternion.identity);
                Instantiate(keese, new Vector3(25, 59, 12), Quaternion.identity);
                Instantiate(keese, new Vector3(21, 59, 12), Quaternion.identity);
                Instantiate(keese, new Vector3(25, 57, 12), Quaternion.identity);
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
        if (roomNumber == 1) return isEmptyList(enemy_1_2);
        else if (roomNumber == 2) return isEmptyList(enemy_1_3);
        else if (roomNumber == 3) return isEmptyList(enemy_4_4);
        return false;
    }
    public static bool RequirementAchieved(int roomNumber)
    {
        if (roomNumber == 1 || roomNumber == 3) return true;
        else if (roomNumber == 2)
        {
            if (pushableBlock != null && pushableBlock.transform.position != initial_block_position)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnKey(Vector3 position, int roomNumber)
    {
        Instantiate(key, position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(keySpawnSound, Camera.main.transform.position);
        key_is_taken[roomNumber] = true;
    }

    IEnumerator PlayAquamentusAudio()
    {
        while (true)
        {
            if (currentRoom == new Vector2(4, 3) && (!visitedRooms.Contains(new Vector2(4, 4)) || GameObject.Find("Aquamentus(Clone)") != null))
            {
                aquamentusAudioSource.Play();
            }
            yield return new WaitForSeconds(2.25f);
        }
    }
}
