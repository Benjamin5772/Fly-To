using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public int Value { get; set; } = 0;

    private bool IsGameStart = false;

    private float spawnInterval = 2.0f;

    public EnemyManager EnemyManager { get; private set; }

    public void OnGameStart()
    {
        IsGameStart = true;
    }

    public void OnGameEnd()
    {
        EnemyManager.Cleaup();
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