using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfBossPhaseMatch : TaskNode
{

    private int _bossPhase = 0;
    public CheckIfBossPhaseMatch(Blackboard i_Blackboard, int i_BossPhase) : base(i_Blackboard) 
    {
        _bossPhase = i_BossPhase;
    }

    public override NodeState Check()
    {
        object obj = GetData("BossPhase");
        if (obj != null)
        {
            int CurrentBossPhase = (int)obj;
            if (CurrentBossPhase == _bossPhase)
            {
                //Debug.Log("Boss phase is " + CurrentBossPhase);
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }
}
