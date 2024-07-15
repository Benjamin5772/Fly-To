using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfBossWakeUp : TaskNode
{
    public CheckIfBossWakeUp(Blackboard i_Blackboard) : base(i_Blackboard) { }

    public override NodeState Check()
    {
        object obj = GetData("BossWakeUp");
        if (obj != null)
        {
            bool BossWakeUp = (bool)obj;
            if (BossWakeUp)
            {
                //Debug.Log("Boss phase is " + CurrentBossPhase);
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }
}