using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfBossPhaseOne : Node
{
    private Blackboard _blackboard;

    public CheckIfBossPhaseOne(Blackboard i_Blackboard)
    {
        _blackboard = i_Blackboard;
    }

    public override NodeState Check()
    {
        if (_blackboard != null)
        {
            object obj = _blackboard.GetData("BossPhase");
            if (obj != null)
            {
                int CurrentBossPhase = (int)obj;
                if (CurrentBossPhase == 1)
                {
                    Debug.Log("Boss phase is one");
                    return NodeState.SUCCESS;
                }
            }
            else
            {
                Debug.Log("Boss phase data is null!");
            }
        }
        else
        {
            Debug.Log("blackboard data is null!");
        }

        return NodeState.FAILURE;
    }
}
