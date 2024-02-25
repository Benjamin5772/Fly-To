using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Mesh mesh; // delete
    public string type;
    public GameObject target;

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
}
