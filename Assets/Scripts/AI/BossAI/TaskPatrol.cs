using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskPatrol : Node
{
    public override NodeState Check()
    {
        // 检测是否进入boss范围

        //如果进入了boss范围
        return NodeState.SUCCESS;
        //如果没有进入boss范围
        // return NodeState.FAULIURE;
    }
}
