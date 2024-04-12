using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode MoveUp,MoveDown,MoveLeft, MoveRight, MoveJump;
    public float mouseSens = 3.0f, speed = 10.0f, jumpForce = 2.0f;
    private bool isGrounded;

    private Rigidbody rb;
    [SerializeField] GameObject camholder;
    private Transform mainCameraTransform;
    private SaveManager saveManager;
    private float camRotate;
    private int lowestY = -70; // var to indicate death of player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
        saveManager = GameObject.FindGameObjectWithTag("save").GetComponent<SaveManager>();
        transform.position = saveManager.lastCheckpoint;

       UpdateControllers();
    }

    void Update()
    {
        groundedCheck();
        Move();
        RotateCam();
        //isDead();
    }

    void groundedCheck()
    {
        // isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
        isGrounded = GetComponentInChildren<GroundedCheck>().isGrounded();
    }

    /*private void isDead() {
        if (transform.position.y <= lowestY) {
            transform.position = saveManager.lastCheckpoint;
        }
    }*/

    public void UpdateControllers() {
        MoveUp = saveManager.MoveUp;
        MoveDown = saveManager.MoveDown;
        MoveLeft = saveManager.MoveLeft;
        MoveRight = saveManager.MoveRight;
        MoveJump = saveManager.MoveJump;
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Checks if the player collides with different physics materials
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.sharedMaterial != null) {
            PhysicMaterial material = collision.collider.sharedMaterial;
            if (material.name == "Slippery") {
                speed = 15;
                jumpForce = 5;
            }
            if (material.name == "Sticky") {
                speed = 6;
                jumpForce = 4;
            }
            if (material.name == "Bouncy") {
                speed = 10;
                jumpForce = 7;
            }
        }
        else { // if there's no special material
            speed = 10;
            jumpForce = 5;
        }
    }

    private void RotateCam()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSens);
        camRotate += (Input.GetAxis("Mouse Y") * mouseSens * -1);
        camRotate = Math.Clamp(camRotate, -90f, 90f);
        camholder.transform.eulerAngles = new Vector3(camRotate, camholder.transform.eulerAngles.y, camholder.transform.eulerAngles.z);
    }


    //DEATH DETECTOR
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "DEATH")
        {
            transform.position = saveManager.lastCheckpoint;
        }
    }
}
