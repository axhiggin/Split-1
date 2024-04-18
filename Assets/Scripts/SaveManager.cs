using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public Vector3 lastCheckpoint;
    private List<KeyCode> keyList = new List<KeyCode>();

    public KeyCode MoveUp,MoveDown,MoveLeft, MoveRight, MoveJump;
    public TextMeshProUGUI tmpText;

    void Awake() {
        
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
            // Initial poisiton
            lastCheckpoint = GameObject.Find("Player").transform.position;
            // List of all controllers
            InitiateList();
            // Initial controllers
            chooseNewControllers();            
        } else {
            Destroy(gameObject);
        }
    }

    private void InitiateList() {
        // Up list

        // Left list

        // Right list

        // Down list

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
        
        // tmpText.text = "  " + MoveUp.ToString() + "  \n" + MoveLeft.ToString() + " " + MoveDown.ToString() + " " + MoveRight.ToString() + "\nJump: " + MoveJump.ToString();
    }
}
