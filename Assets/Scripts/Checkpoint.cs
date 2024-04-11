using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Checkpoint instance;
    private SaveManager saveManager;
    private PlayerMovement player;

    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("save").GetComponent<SaveManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            saveManager.lastCheckpoint = transform.position;
            Destroy(gameObject);
            saveManager.chooseNewControllers();
            player.UpdateControllers();
        }
    }
}
