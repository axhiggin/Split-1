using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public Vector3 lastCheckpoint;
    private List<KeyCode> keyList = new List<KeyCode>();

    public KeyCode MoveUp,MoveDown,MoveLeft, MoveRight, MoveJump;


    void Awake() {
        
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
            // Initial poisiton
            lastCheckpoint = new Vector3(0.1919389f, -38.40644f, 37.32944f);
            // List of all controllers
            InitiateList();
            // Initial controllers
            chooseNewControllers();            
        } else {
            Destroy(gameObject);
        }
    }

    private void InitiateList() {
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
    }

    public void chooseNewControllers() {
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
}
