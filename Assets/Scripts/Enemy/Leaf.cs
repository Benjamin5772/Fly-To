using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : BaseEnemy
{

    private Vector3 targetPosition;

    public float attackCooldown = 2f; // attack cd
    private float nextAttackTime = 0; // next attack

    void Start()
    {
        Spawn(); 
            
        //仅记录一次位置
        if (target != null)
        {
            targetPosition = target.transform.position;
        }

    }

    private void Update()
    {
        
        Move();
        AttackTimeCheck();

    }

    // 在指定范围内随机生成位置
    //写到了Enemy Manager

    //todo 更复杂的攻击轨迹，而不是只是直线
    protected override void Move()
    {
        if (target != null)
        {

            if (targetPosition != Vector3.zero) 
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            ApplyEffect();
        }
    }

    // 效果逻辑
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        
        Debug.Log("Leaf hit the player, applying damage.");
    }

    // cd check
    public override void AttackTimeCheck()
    {
        
        if (Time.time >= nextAttackTime)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 1f)
            {
                ApplyEffect(); 
                nextAttackTime = Time.time + attackCooldown; // undate next attack
            }
        }

    }
}


