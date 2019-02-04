﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void SetMultiplayer(bool isOn)
    {
        GameValues.IsMultiplayer = isOn;
    }
   
}
