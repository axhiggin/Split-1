using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour, IInteractable
{

    public void Hover()
    {
        UIManager.Instance.InteractTextOn("press E to go to sleep");
    }
    public void Interact()
    {
        SceneManager.LoadScene("EndScene");
    }
}
