using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public int Value { get; set; } = 0;

    private bool IsGameStart = false;

    private float spawnInterval = 2.0f;

    public EnemyManager EnemyManager { get; private set; }

    public HUDController HUDController { get; private set; }

    private void Start()
    {
        //所有manager的init
        HUDController.Init();
    }

    public void OnGameStart()
    {
        IsGameStart = true;
        HUDController.OnGameStart();
    }

    public void OnGameEnd()
    {
        EnemyManager.Cleaup();
    }

    public void Exit()
    {
        // 退出游戏
        // TODO
    }

    private IEnumerator SpawnEnemy()
    {
        while (IsGameStart)
        {
            EnemyManager.CallSpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}