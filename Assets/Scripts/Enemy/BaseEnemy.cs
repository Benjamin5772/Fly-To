using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Mesh mesh; // delete
    public PlayerController target;

    //碰撞检测
    //TODO

    protected virtual void Move()
    {
      
    }

    protected virtual void Spawn()
    {
        
    }

    public virtual void OnDead()
    {
        //todo 摧毁逻辑
        Destroy(gameObject);
    }

    public virtual void ApplyEffect()
    {
       
    }

    public virtual void AttackTimeCheck()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player enter the trigger box!");
        if (other.gameObject == target.gameObject)
        {
            Debug.Log("Apply effect to player!");
            ApplyEffect();
        }
    }

    public void TriggerAnimationEvent(string i_s)
    {
        string[] stringAfterSplit = i_s.Split(',');
    }
}
