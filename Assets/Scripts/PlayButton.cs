using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(toPlayScene);
    }

    // Update is called once per frame
    void toPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
