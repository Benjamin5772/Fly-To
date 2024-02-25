using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 记得改成singleton
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public float spawnDistance = 10f;
    public float spawnWidth = 5f;
    public float spawnHeight = 2f;
    public GameObject player;

    private List<GameObject> enemies = new List<GameObject>();

    private bool isSpawnEnemy = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (isSpawnEnemy)
        {
            CallSpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void CallSpawnEnemy()
    {
        Vector3 spawnPos = CalculateSpawnPosition();
        GameObject enemy = InstantiateEnemy(spawnPos);
        enemies.Add(enemy); 
    }

    //计算位置
    private Vector3 CalculateSpawnPosition()
    {
        Vector3 forwardOffset = player.transform.forward * spawnDistance;
        float randomWidthOffset = Random.Range(-spawnWidth, spawnWidth);
        Vector3 widthOffset = player.transform.right * randomWidthOffset;
        Vector3 heightOffset = new Vector3(0, spawnHeight, 0);
        Vector3 spawnPos = player.transform.position + forwardOffset + widthOffset + heightOffset;
        return spawnPos;
    }
    
    //生成敌人
    private GameObject InstantiateEnemy(Vector3 spawnPos)
    {
        Vector3 forwardOffset = player.transform.position - spawnPos;
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.LookRotation(forwardOffset));
        BaseEnemy enemyScript = enemy.GetComponent<BaseEnemy>();
        if (enemyScript != null)
        {
            enemyScript.target = player;
        }
        return enemy;
    }
    //清除敌人
    public void Cleaup()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear(); 
    }
}

