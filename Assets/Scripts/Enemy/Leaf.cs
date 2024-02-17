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

    // ��ָ����Χ���������λ��
    //д����Enemy Manager

    //todo �����ӵĹ����켣��������ֻ��ֱ��
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


