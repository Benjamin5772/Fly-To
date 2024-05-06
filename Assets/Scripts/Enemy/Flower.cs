using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BaseEnemy
{
    public EnemyManager m_EnemyManager;

    public void Init(EnemyManager i_EnemyManager)
    {
        m_EnemyManager = i_EnemyManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player enter the trigger box!");
        if (other.gameObject == target.gameObject)
        {
            ApplyEffect();
        }
    }

    // Ð§¹ûÂß¼­
    public override void ApplyEffect()
    {
        base.ApplyEffect();

        Destroy(this);
    }
}
