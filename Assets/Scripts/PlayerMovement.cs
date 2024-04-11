using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private List<KeyCode> keyList = new List<KeyCode>();
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode MoveJump;
    public float speed = 10, jumpForce = 2;
    private bool isGrounded;

    private Rigidbody rb;

    void Start()
    {
        //getting rigidbody component from player
        rb = GetComponent<Rigidbody>();

        // Add all keyboard keys to a list

        // foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        // {
        //     keyList.Add(keyCode);
        // }
        
        // Add numbers to the list
        for (int i = (int)KeyCode.Alpha0; i <= (int)KeyCode.Alpha9; i++)
        {
            keyList.Add((KeyCode)i);
        }

        // Add letters to the list
        for (int i = (int)KeyCode.A; i <= (int)KeyCode.Z; i++)
        {
            keyList.Add((KeyCode)i);
        }

        // Add arrow keys to the list
        keyList.Add(KeyCode.UpArrow);
        keyList.Add(KeyCode.DownArrow);
        keyList.Add(KeyCode.LeftArrow);
        keyList.Add(KeyCode.RightArrow);

        // Choose random values
        int randomIndex = Random.Range(0, keyList.Count);
        MoveUp = keyList[randomIndex];
        keyList.Remove(keyList[randomIndex]);
        randomIndex = Random.Range(0, keyList.Count);
        MoveDown = keyList[randomIndex];
        keyList.Remove(keyList[randomIndex]);
        randomIndex = Random.Range(0, keyList.Count);
        MoveRight = keyList[randomIndex];
        keyList.Remove(keyList[randomIndex]);
        randomIndex = Random.Range(0, keyList.Count);
        MoveLeft = keyList[randomIndex];
        keyList.Remove(keyList[randomIndex]);
        randomIndex = Random.Range(0, keyList.Count);
        MoveJump = keyList[randomIndex];
        keyList.Remove(keyList[randomIndex]);


    }

    // Update is called once per frame
    void Update()
    {
        groundedCheck();
        Move();
    }

    void groundedCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
    }

    void Move()
    {
        if (Input.GetKey(MoveUp))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(MoveDown))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(MoveLeft))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(MoveRight))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(MoveJump) && isGrounded)
        {
            Debug.Log("JUMP");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
