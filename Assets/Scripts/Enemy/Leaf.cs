using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : BaseEnemy
{

    private Vector3 targetPosition;

    public float attackCooldown = 2f; // attack cd
    private float nextAttackTime = 0; // next attack

    // �����ƶ�
    public float moveRandomness = 1f; 
    private Vector3 randomDirection; 

    // ���������
    public float directionUpdateInterval = 2f; 
    private float nextDirectionUpdateTime = 0; 



    void Start()
    {
        Spawn(); 
            
        //����¼һ��λ��
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

    protected override void Move()
    {
        if (target != null && targetPosition != Vector3.zero)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized + randomDirection;
            moveDirection = moveDirection.normalized; 
            transform.position += moveDirection * speed * Time.deltaTime;

            // ������ʱ��
            if (Time.time >= nextDirectionUpdateTime)
            {
                UpdateRandomDirection();
                nextDirectionUpdateTime = Time.time + directionUpdateInterval; 
            }
        }
    }

    private void UpdateRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-moveRandomness, moveRandomness), 0, Random.Range(-moveRandomness, moveRandomness));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            ApplyEffect();
        }
    }

    // Ч���߼�
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


