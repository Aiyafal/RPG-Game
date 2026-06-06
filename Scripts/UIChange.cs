using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIChange : MonoBehaviour
{
    const string GAMEPAUSE_UI = "GamePause";
    [SerializeField] private GameObject gamePause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(GAMEPAUSE_UI);
    }

    
}
