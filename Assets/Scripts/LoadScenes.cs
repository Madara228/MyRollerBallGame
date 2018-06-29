using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour {

    public Button newScene;
    public Button tutorial;
    float xFactor, yFactor;


	void Start () {
        xFactor = Screen.width;
        yFactor = Screen.height;
        Debug.Log(xFactor+" "+ yFactor);
        newScene = newScene.GetComponent<Button>();
       // tutorial = tutorial.GetComponent<Button>();
        newScene.onClick.AddListener(newScene_void);
	}


    void newScene_void()
    {
        if (yFactor == 1920 && xFactor == 1080 || yFactor == 1080 && xFactor == 1920)
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(yFactor == 1280 && xFactor == 720 || yFactor == 720 && xFactor == 1280)
        {
            SceneManager.LoadScene("MainScene_720p");
        }
    }
}
