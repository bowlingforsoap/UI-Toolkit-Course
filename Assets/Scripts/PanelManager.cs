using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public UIDocument mainMenuScreen;
    public UIDocument gameScreen;
    public UIDocument settingsScreen;

    private int maxAmmoCount = 10;
    private int currentAmmo;

    private Label ammoCountLabel;

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
            startButton.clicked += () =>
            {
                GoToGameScreen();
                ResetGame();
            };
        }

        var settingsButton = mainMenuScreen.rootVisualElement.Q<Button>("settings-button");
        if (settingsButton != null)
        {
            settingsButton.clicked += GoToSettingsScreen;
        }
        
        var exitButton = mainMenuScreen.rootVisualElement.Q<Button>("exit-button");
        if (exitButton != null)
        {
            exitButton.clicked += Application.Quit;
        }
    }

    private void BindGameScreen()
    {
        ammoCountLabel = gameScreen.rootVisualElement.Q<Label>("ammo-count");

        var shootButton = gameScreen.rootVisualElement.Q<Button>("shoot-button");
        if (shootButton != null)
        {
            shootButton.clicked += () =>
            {
                if (currentAmmo > 0 & ammoCountLabel != null)
                {
                    ammoCountLabel.text = --currentAmmo + " / " + maxAmmoCount;
                }
            };
        }

        var reloadButton = gameScreen.rootVisualElement.Q<Button>("reload-button");
        if (reloadButton != null)
        {
            reloadButton.clicked += ResetGame;
        }
        
        var backToMenuButton = gameScreen.rootVisualElement.Q<Button>("back-button");
        if (backToMenuButton != null)
        {
            backToMenuButton.clicked += GoToMainScreen;
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
        SetUIDocumentEnabledState(gameScreen, false);
        SetUIDocumentEnabledState(settingsScreen, false);
        BindMainMenuScreen();
    }

    private void GoToGameScreen()
    {
        SetUIDocumentEnabledState(gameScreen, true);
        SetUIDocumentEnabledState(mainMenuScreen, false);
        SetUIDocumentEnabledState(settingsScreen, false);
        BindGameScreen();
    }
    
    private void GoToSettingsScreen()
    {
        SetUIDocumentEnabledState(settingsScreen, true);
        SetUIDocumentEnabledState(mainMenuScreen, false);
        SetUIDocumentEnabledState(gameScreen, false);
        BindSettingsScreen();
    }
    
    private void ResetGame()
    {
        currentAmmo = maxAmmoCount;
        if (ammoCountLabel != null)
        {
            ammoCountLabel.text = currentAmmo + " / " + maxAmmoCount;
        }
    }
}
