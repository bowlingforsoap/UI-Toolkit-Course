using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public UIDocument mainMenuScreen;
    public UIDocument gameScreen;

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
        BindMainMenuScreen();
    }

    private void GoToGameScreen()
    {
        SetUIDocumentEnabledState(gameScreen, true);
        SetUIDocumentEnabledState(mainMenuScreen, false);
        BindGameScreen();
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
