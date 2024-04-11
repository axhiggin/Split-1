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
    private Transform mainCameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;

        // Add all keyboard keys to a list
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
        if (Input.GetKey(MoveUp) || Input.GetKey(MoveDown) || Input.GetKey(MoveLeft) || Input.GetKey(MoveRight))
        {
            // Calculate the movement direction based on camera's forward direction
            Vector3 movementDirection = mainCameraTransform.forward;
            movementDirection.y = 0; // Remove vertical component
            movementDirection = movementDirection.normalized;

            // Rotate the player to face the movement direction
            if (movementDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(movementDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            }

            // Move the player based on pressed keys
            Vector3 movement = Vector3.zero;
            if (Input.GetKey(MoveUp))
                movement += Vector3.forward;
            if (Input.GetKey(MoveDown))
                movement += Vector3.back;
            if (Input.GetKey(MoveLeft))
                movement += Vector3.left;
            if (Input.GetKey(MoveRight))
                movement += Vector3.right;

            transform.Translate(movement.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(MoveJump) && isGrounded)
        {
            Debug.Log("JUMP");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
