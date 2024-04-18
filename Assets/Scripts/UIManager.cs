using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }





    //INTERACTION
    public void InteractTextOn(string text)
    {
        Transform interactUI = transform.Find("InteractText");
        if (text == null)
        {
            interactUI.gameObject.SetActive(true);
        }
        else
        {
            interactUI.GetComponent<TextMeshProUGUI>().text = text;
            interactUI.gameObject.SetActive(true);
        }
        
    }

    public void InteractTextOff()
    {
        Transform interactUI = transform.Find("InteractText");
        interactUI.gameObject.SetActive(false);
    }
}
