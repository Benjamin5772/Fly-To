using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : BaseEnemy
{
    public float spawnInterval = 10f; // ���ܳ��ֵļ��ʱ��
    public float removalDistance = 10f; // ����뻤�ܵ�������
    private float nextSpawnTime = 0f;
    private List<GameObject> shields = new List<GameObject>();
    private GameObject attachedShield = null; // ������ҵĻ���

    //��ǰ�����ɻ���
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
            // �������뻤�ܾ����Զ�һ��ܲ��Ǹ���Ļ��ܣ������ٻ���
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
            ApplyEffect(); // Ӧ�������˺�Ч��
            if (attachedShield == null) 
            {
                attachedShield = gameObject; 
                StartCoroutine(RemoveAfterDelay(5f)); // 5����Ƴ�����
            }
        }
    }

    //���ܸ�����ҹ���
    void ShieldFollow(GameObject followTarget)
    {
        attachedShield.transform.position = followTarget.transform.position; // �û��ܸ������
    }

    // ������滤�ܵ�����
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
        // ʵ�������˺�Ч��
        Debug.Log("Apply hurt immunity");
    }
}
