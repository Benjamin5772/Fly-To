using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed = 5.0f;
    public GameObject hairballPrefab;
    public Transform hairballSpawnPoint;
    public float hairballInterval = 2.0f;
    
    private void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(ShootHairball());
    }

    private void Update()
    {
        MoveBoss();
    }

    private void MoveBoss()
    {
        // ÏòÇ°ÒÆ¶¯Âß¼­
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator ShootHairball()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(hairballInterval);
            Instantiate(hairballPrefab, hairballSpawnPoint.position, hairballSpawnPoint.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss died");
        Destroy(gameObject);
    }
}
