using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Shoot : TaskNode
{

    private GameObject _furballRef;
    private int _bossPhase = 0;

    public Shoot(Blackboard i_Blackboard, GameObject i_FurballRef, int bossPhase) : base(i_Blackboard)
    {
        _furballRef = i_FurballRef;
        _bossPhase = bossPhase;
    }

    public override NodeState Check()
    {
        if (_furballRef != null)
        {
            // 根据_furballRef生成毛球
            // 1.根据_bossphase来判断发射一个毛球还是两个
            // 2.传入animator改变boss动画状态
            // TODO

            Debug.Log("Shoot!");

            return NodeState.SUCCESS;
        }
        else
        {
            Debug.Log("_furballRef is null!");
        }

        return NodeState.FAILURE;
    }

}
