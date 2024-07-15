using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundEnemy : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ApplyEffect()
    {
        base.ApplyEffect();

        target.SetCurrentReboundEnemy(this);
    }

    public virtual void Rebound()
    {
        // override
    }

    public void DamagePlayer()
    {

    }

    public void DamageBoss()
    {

    }
      
}
