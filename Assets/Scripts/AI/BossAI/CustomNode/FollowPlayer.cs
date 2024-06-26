using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class FollowPlayer : TaskNode
{
    private Transform _transform;

    public FollowPlayer(Blackboard i_Blackboard, Transform i_Transform) : base(i_Blackboard)
    {
        _transform = i_Transform;
    }

    public override NodeState Check()
    {
        object obj = GetData("PlayerRef");
        if (obj != null)
        {
            PlayerController CurrentPlayerCharacter = (PlayerController)obj;
            if (CurrentPlayerCharacter != null)
            {
                // 根据玩家的位置，去移动boss
                // TODO

                return NodeState.RUNNING;
            }
        }

        return NodeState.FAILURE;
    }
}
