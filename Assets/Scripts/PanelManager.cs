using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public UIDocument mainMenuScreen;
    public UIDocument settingsScreen;

    private void Start()
    {
        GoToMainScreen();
    }

    // Has to be called each time the screen is enabled.
    private void BindMainMenuScreen()
    {
        var startButton = mainMenuScreen.rootVisualElement.Q<Button>("start-button");
        if (startButton != null)
        {
            startButton.clicked += () => Debug.Log("Start Button Clicked");
        }

        var settingsButton = mainMenuScreen.rootVisualElement.Q<Button>("settings-button");
        if (settingsButton != null)
        {
            settingsButton.clicked += () =>
            {
                Debug.Log("Settings Button Clicked");
                GoToSettingsScreen();
            };
        }
        
        var exitButton = mainMenuScreen.rootVisualElement.Q<Button>("exit-button");
        if (exitButton != null)
        {
            exitButton.clicked += () => Debug.Log("Exit Button Clicked");
            Application.Quit();
        }
    }

    // Has to be called each time the screen is enabled.
    private void BindSettingsScreen()
    {
        var backButton = settingsScreen.rootVisualElement.Q<Button>("back-button");
        if (backButton != null)
        {
            backButton.clickable.clicked += () =>
            {
                Debug.Log("Back Button Clicked");
                GoToMainScreen();
            };
        }
    }
    
    private void SetUIDocumentEnabledState(UIDocument uiDocument, bool finalState)
    {
        uiDocument.enabled = finalState;
        
        /*DisplayStyle targetFlex;
        if (finalState)
        {
             targetFlex = DisplayStyle.Flex;
        }
        else
        {
            targetFlex = DisplayStyle.None;
        }
        uiDocument.rootVisualElement.style.display = targetFlex;*/
    }

    private void GoToMainScreen()
    {
        SetUIDocumentEnabledState(mainMenuScreen, true);
        SetUIDocumentEnabledState(settingsScreen, false);
        BindMainMenuScreen();
    }

    private void GoToSettingsScreen()
    {
        SetUIDocumentEnabledState(settingsScreen, true);
        SetUIDocumentEnabledState(mainMenuScreen, false);
        BindSettingsScreen();
    }
}
