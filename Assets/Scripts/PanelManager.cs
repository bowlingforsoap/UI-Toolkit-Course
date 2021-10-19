using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public UIDocument mainMenuScreen;

    private void OnEnable()
    {
        BindMainMenuScreen();
    }

    private void BindMainMenuScreen()
    {
        var startButton = mainMenuScreen.rootVisualElement.Q<Button>("start-button");
        if (startButton != null)
        {
            startButton.clickable.clicked += () => Debug.Log("Start Button Clicked");
        }
    }
}
