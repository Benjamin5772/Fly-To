using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public int Value { get; set; } = 0;

    private bool IsGameStart = false;
    private bool IsGamePause = false;

    private float spawnInterval = 2.0f;

    public EnemyManager EnemyManager;

    public HUDController HUDController;

    public PlayerController m_PlayerController;

    //public Database m_Data;


    /// <summary>
    /// Camera control
    /// </summary>
    public Camera mainMenuCamera;
    public GameObject rotatingObject;
    public PlayerState playerState = new PlayerState();
    public float screenMoveSpeed = 0.01f;
    public float cameraMoveTime = 1.5f;
    public Vector3 rotationAngle = new Vector3(0, 90, 0); // 可调的旋转角度

    private void Start()
    {
        //所有manager的init
        EnemyManager.Init(m_PlayerController);
        HUDController.Init(m_PlayerController.GetPlayerState());
    }

    public void OnGameStart()
    {
        IsGameStart = true;

        //旋转摄像机
        StartCoroutine(RotateAndMoveCamera());
        //旋转物体
        if (rotatingObject != null)
        {
            StartCoroutine(RotateObject(rotatingObject, rotationAngle, cameraMoveTime));
        }

        HUDController.OnGameStart();
        StartCoroutine(SwitchUIAfterDelay());
    }

    public void OnGameEnd()
    {
        IsGameStart = false;
        EnemyManager.OnGameEnd();
        // Hud and playercontroller ongameend function call;
    }

    public void OnGameReload(SaveDataStr i_SDS)
    {
        // 更新玩家血量
        m_PlayerController.ForceUpdatePlayerHealth(i_SDS.Health);
        UpdateHealth();
        // 更新玩家save object
        SaveManager.Instance.LoadFromSaveData(i_SDS.SaveObjectID, m_PlayerController);
        // 更新玩家flowernumber
        m_PlayerController.ForceUpdatePlayerFlowerNumber(i_SDS.FlowerNumber);

        // Start the game
        // TODO
    }

    public void Exit()
    {
        // 退出游戏
        // TODO
    }

    public void GamePauseAndReleaseFuntion()
    {
        if (IsGameStart)
        {
            if (IsGamePause)
            {
                HUDController.OnPlayerReleaseGame();
                Time.timeScale = 1.0f;
                IsGamePause = false;
            }
            else
            {
                HUDController.OnPlayerPauseGame();
                Time.timeScale = 0.0f;
                IsGamePause = true;
            }
        }
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (IsGameStart)
        {
            EnemyManager.CallSpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 隐藏开始界面，打开游戏内ui
    private IEnumerator SwitchUIAfterDelay()
    {
        yield return new WaitForSeconds(cameraMoveTime);
        HUDController.OpenInGameMenu();
        m_PlayerController.OnGameStart();
        EnemyManager.OnGameStart();
    }

    private IEnumerator RotateAndMoveCamera()
    {
        Quaternion originalRotation = mainMenuCamera.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(mainMenuCamera.transform.eulerAngles.x, mainMenuCamera.transform.eulerAngles.y + 90, mainMenuCamera.transform.eulerAngles.z);

        float elapsedTime = 0f;
        float duration = cameraMoveTime; // 旋转持续时间

        Vector3 rotationCenter = rotatingObject != null ? rotatingObject.transform.position : Vector3.zero;

        float rotationAmount = rotationAngle.y / cameraMoveTime;

        // 旋转过程
        while (elapsedTime < duration)
        {
            mainMenuCamera.transform.RotateAround(rotationCenter, Vector3.up, rotationAmount * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainMenuCamera.transform.rotation = targetRotation;

        //GameManager.Instance.OnGameStart();

        // 移动摄像机
        while (true)
        {
            mainMenuCamera.transform.Translate(Vector3.forward * Time.deltaTime * screenMoveSpeed, Space.World);
            yield return null;
        }

    }

    // 旋转物体
    private IEnumerator RotateObject(GameObject obj, Vector3 angle, float duration)
    {
        Quaternion originalRotation = obj.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(obj.transform.eulerAngles + angle);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            obj.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = targetRotation;
    }

    // UI Update
    // Update health bar

    public void UpdateInGameUI(Enum i_UpdateType, UIData i_Data)
    {

    }
    public void UpdateHealth()
    {
        HUDController.UpdateHealth();
    }

    public float GetPlayerHealth()
    {
        float RetVal = 0.0f;
        RetVal = m_PlayerController.GetPlayerHealth();
        return RetVal;
    }

    public int GetPlayerFlowerNumber()
    {
        int RetVal = 0;
        RetVal = m_PlayerController.GetPlayerFlowerNumber();
        return RetVal;
    }


}

public class UIData
{
    float health;
    float fuel;
}