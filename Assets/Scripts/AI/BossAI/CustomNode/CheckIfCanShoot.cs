using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfCanShoot : TaskNode
{

    private float _duration;
    private float _currentDuration;

    public CheckIfCanShoot(Blackboard i_Blackboard, float i_Duration) : base(i_Blackboard)
    {
        _duration = i_Duration;
    }

    public override NodeState Check()
    {
        _currentDuration += Time.deltaTime;

        if (_currentDuration < _duration)
        {
            return NodeState.FAILURE;
        }
        else
        {
            _currentDuration = 0;
            Debug.Log("Need to shoot!");
            return NodeState.SUCCESS;
        }
    }

}
