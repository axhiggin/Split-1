using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Checkpoint instance;
    private SaveManager saveManager;
    private SoundEffects musicManager;
    private PlayerMovement player;

    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("save").GetComponent<SaveManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<SoundEffects>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(playSounds());            
        }
    }

    IEnumerator playSounds() {
        musicManager.chugMusic();
        yield return new WaitForSeconds(1);
        musicManager.burpMusic();
        saveManager.lastCheckpoint = transform.position;
        Destroy(gameObject);
        saveManager.chooseNewControllers();
        player.UpdateControllers();
    }
}
