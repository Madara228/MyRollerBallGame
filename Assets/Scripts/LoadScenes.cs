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
        
            SceneManager.LoadScene("MainScene");
        
    }
}
