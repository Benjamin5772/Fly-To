using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // enemy
    public float spawnInterval = 5f; //  spawn cd
    public float spawnDistance = 10f; // horizontal distance
    public float spawnWidth = 5f; // horizontal width
    public float spawnHeight = 2f; // vertical distance
    public GameObject player; // player

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // 计算生成位置
            Vector3 forwardOffset = player.transform.forward * spawnDistance;
            float randomWidthOffset = Random.Range(-spawnWidth, spawnWidth);
            Vector3 widthOffset = player.transform.right * randomWidthOffset;
            Vector3 heightOffset = new Vector3(0, spawnHeight, 0);

            //final pos
            Vector3 spawnPos = player.transform.position + forwardOffset + widthOffset + heightOffset;

 
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.LookRotation(-forwardOffset));
            BaseEnemy enemyScript = enemy.GetComponent<BaseEnemy>();
            if (enemyScript != null)
            {
                enemyScript.target = player; 
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
