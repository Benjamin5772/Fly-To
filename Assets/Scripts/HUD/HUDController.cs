using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Singleton<HUDController>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        OnGameInit();
    }

    public void OnGameInit()
    {
        // 打开Main menu ui，关闭所有别的UI
    }

    public void OnGameStart()
    {
        // 关闭Main menu ui，打开PlayerInGameUI
    }

    public void OnPlayerPauseGame()
    {
        // 可能关闭PlayerInGameUI，打开InGameMenu
    }
}
