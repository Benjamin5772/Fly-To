using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BaseEnemy
{
    public float pushForce = 5f; // ����
    public float damage = 10f; // �˺�
    public float fuelReduction = 5f; // ���ٵ�ȼ����

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject == target)
        {
            ApplyEffect();

            // ���㷽��
            Vector3 pushDirection = CalculatePushDirection(transform.position, collision.transform.position);

            // Ӧ������
            ApplyPushForce(collision.gameObject, pushDirection, pushForce);

           
        }
    }

    Vector3 CalculatePushDirection(Vector3 source, Vector3 target)
    {
        return (target - source).normalized;
    }

    void ApplyPushForce(GameObject target, Vector3 direction, float force)
    {
        Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
        if (targetRigidbody != null)
        {
            targetRigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }

    public override void ApplyEffect()
    {
        base.ApplyEffect();

        // ���˺��ͼ���ȼ��
        Debug.Log($"Rock hit the player, causing {damage} damage and reducing fuel by {fuelReduction}.");
    }
}
