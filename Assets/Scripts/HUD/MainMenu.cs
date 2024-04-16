using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseWidget
{
    // 开始游戏的按钮
    // 当点下这个按钮之后，调用开始游戏的接口

    //public GameObject gameStartUI;
    //public GameObject inGameUI;

    // Start is called before the first frame update
    void Start()
    {

        //if (gameStartUI != null) gameStartUI.SetActive(true);
        //if (inGameUI != null) inGameUI.SetActive(false);
    }

    public void OnGameStartButtonClicked()
    {
        // 通知Gamemanager开始游戏
        // TODO
        //if (playerState != null)
        //{
        //playerState.GivePushForce = true;
        //}

        GameManager.Instance.OnGameStart();

    }

}