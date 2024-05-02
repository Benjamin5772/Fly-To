using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Singleton<HUDController>
{
    public MainMenu mainMenu;
    public PlayerInGameUI playerInGameUI;
    public InGameMenu inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(PlayerState i_PlayerState)
    {
        playerInGameUI.InitPlayerInGameUI(i_PlayerState);
        OnGameInit();
    }

    public void OnGameInit()
    {
        // 打开Main menu ui，关闭所有别的UI
        if (mainMenu != null)
        {
            mainMenu.ShowWidget();
        }
            
        if (playerInGameUI != null)
        {
            playerInGameUI.HideWidget();
        }
            
        if (inGameMenu != null)
        { 
            inGameMenu.HideWidget();
        }   
    }

    public void OnGameStart()
    {
        // 关闭Main menu ui，打开PlayerInGameUI
        if (mainMenu != null)
        {
            mainMenu.HideWidget();
        }
            
        //if (playerInGameUI != null)
            //playerInGameUI.ShowWidget();
    }

    public void OpenInGameMenu()
    {
        if (playerInGameUI != null)
        {
            playerInGameUI.ShowWidget();
        }
            
    }

    public void OnPlayerPauseGame()
    {
        // 可能关闭PlayerInGameUI，打开InGameMenu
        //if (playerInGameUI != null)
            //playerInGameUI.HideWidget();
        if (inGameMenu != null && playerInGameUI != null)
        {
            inGameMenu.ShowWidget();
            playerInGameUI.HideWidget();
        }
    }

    public void OnPlayerReleaseGame()
    {
        if (inGameMenu != null && playerInGameUI != null)
        {
            inGameMenu.HideWidget();
            playerInGameUI.ShowWidget();
        }
    }

    public void UpdateHealth()
    {
        playerInGameUI.UpdateHealthIcons();
    }
}
