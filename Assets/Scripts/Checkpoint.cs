using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    private static Checkpoint instance;
    private SaveManager saveManager;
    private SoundEffects musicManager;
    private PlayerMovement player;
    private GameObject drinkHolder;

    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("save").GetComponent<SaveManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<SoundEffects>();
        drinkHolder = GameObject.Find("DrinkHolder");
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(playSounds());            
        }
    }*/

    public void Interact()
    {
        transform.SetParent(drinkHolder.transform);
        transform.localPosition = Vector3.zero;
        StartCoroutine(playSounds());
    }

    public void Hover()
    {
        if(name == "everclear")
        {
            UIManager.Instance.InteractTextOn("you probably shouldn't drink this...");
        }
        else
        {
            UIManager.Instance.InteractTextOn("press E to CHUG");
        }
    }

    IEnumerator playSounds() {
        if (name == "everclear")
        {
            saveManager.lastCheckpoint = new Vector3(-68.65f, -44.96f, 41.6f);
            musicManager.chugMusic();
            transform.GetComponent<Collider>().enabled = false;
            transform.GetComponent<Animator>().SetTrigger("DrinkingTime");
            yield return new WaitForSeconds(3);
            musicManager.burpMusic();
            Destroy(gameObject);
            GameObject.Find("Player").transform.position = saveManager.lastCheckpoint;
            saveManager.chooseNewControllers();
            player.UpdateControllers();
        }
        else
        {
            saveManager.lastCheckpoint = transform.position;
            musicManager.chugMusic();
            transform.GetComponent<Collider>().enabled = false;
            transform.GetComponent<Animator>().SetTrigger("DrinkingTime");
            yield return new WaitForSeconds(3);
            musicManager.burpMusic();
            Destroy(gameObject);
            saveManager.chooseNewControllers();
            player.UpdateControllers();
        }
    }
}
