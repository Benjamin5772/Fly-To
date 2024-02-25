using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BaseEnemy
{
    public float pushForce = 5f; // 推力
    public float damage = 10f; // 伤害
    public float fuelReduction = 5f; // 减少的燃料量

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject == target)
        {
            ApplyEffect();

            // 计算方向
            Vector3 pushDirection = CalculatePushDirection(transform.position, collision.transform.position);

            // 应用推力
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

        // 成伤害和减少燃料
        Debug.Log($"Rock hit the player, causing {damage} damage and reducing fuel by {fuelReduction}.");
    }
}
