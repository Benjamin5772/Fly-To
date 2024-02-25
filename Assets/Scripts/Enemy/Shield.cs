using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : BaseEnemy
{
    public float spawnInterval = 10f; // 护盾出现的间隔时间
    public float removalDistance = 10f; // 玩家与护盾的最大距离
    private float nextSpawnTime = 0f;
    private List<GameObject> shields = new List<GameObject>();
    private GameObject attachedShield = null; // 跟随玩家的护盾

    //在前方生成护盾
    protected override void Spawn()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject shield = Instantiate(gameObject, target.transform.position + target.transform.forward * 2, Quaternion.identity); 
            shields.Add(shield); 
            nextSpawnTime = Time.time + spawnInterval; 
        }
    }

    void Update()
    {
        Spawn();

        for (int i = shields.Count - 1; i >= 0; i--)
        {
            if (shields[i] == null)
            {
                shields.RemoveAt(i);
            }
            // 如果玩家与护盾距离过远且护盾不是跟随的护盾，则销毁护盾
            else if (Vector3.Distance(target.transform.position, shields[i].transform.position) > removalDistance && shields[i] != attachedShield) 
            {
                Destroy(shields[i]);
                shields.RemoveAt(i);
            }
        }

        if (attachedShield != null)
        {
           
            ShieldFollow(target);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target) 
        {
            ApplyEffect(); // 应用免疫伤害效果
            if (attachedShield == null) 
            {
                attachedShield = gameObject; 
                StartCoroutine(RemoveAfterDelay(5f)); // 5秒后移除护盾
            }
        }
    }

    //护盾跟随玩家功能
    void ShieldFollow(GameObject followTarget)
    {
        attachedShield.transform.position = followTarget.transform.position; // 让护盾跟随玩家
    }

    // 清除跟随护盾的引用
    IEnumerator RemoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (attachedShield != null)
        {
            shields.Remove(attachedShield);
            Destroy(attachedShield);
            attachedShield = null; 
        }
    }

    public override void ApplyEffect()
    {
        // 实现免疫伤害效果
        Debug.Log("Apply hurt immunity");
    }
}
