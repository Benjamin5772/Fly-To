using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : ReboundEnemy
{

    private Vector3 targetPosition;
    public float attackCooldown = 2f; // attack cd
    private float nextAttackTime = 0; // next attack

    // ÇúÕÛÒÆ¶¯
    public float moveRandomness = 1f; 
    private Vector3 randomDirection; 

    // Ëæ»ú·½Ïò¼ä¸ô
    public float directionUpdateInterval = 2f; 
    private float nextDirectionUpdateTime = 0;

    public float Damage = 1f;

    void Start()
    {
        Spawn(); 
            
        //½ö¼ÇÂ¼Ò»´ÎÎ»ÖÃ
        if (target != null)
        {
            targetPosition = target.transform.position;
        }

    }

    private void Update()
    {
        
        Move();
        //AttackTimeCheck();

    }

    protected override void Move()
    {
        if (target != null && targetPosition != Vector3.zero)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized + randomDirection;
            moveDirection = moveDirection.normalized; 
            transform.position += moveDirection * speed * Time.deltaTime;

            // ¼ì²é¸üÐÂÊ±¼ä
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


    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("Player enter the trigger box!");
    //    if (other.gameObject == target.gameObject)
    //    {
    //        Debug.Log("Apply effect to player!");
    //        ApplyEffect();
    //    }
    //}

    // Ð§¹ûÂß¼­
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        
        Debug.Log("Leaf hit the player, applying damage.");

        if (Time.time >= nextAttackTime)
        {
            target.ApplyDamage(Damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    // cd check
    //public override void AttackTimeCheck()
    //{

    //if (Time.time >= nextAttackTime)
    //{
    //if (Vector3.Distance(transform.position, target.transform.position) < 1f)
    //{
    // ApplyEffect();

    //nextAttackTime = Time.time + attackCooldown; // undate next attack
    //}
    //}

    //}

    public override void Rebound()
    {
        base.Rebound();
        //执行弹反，消失
    }
}


