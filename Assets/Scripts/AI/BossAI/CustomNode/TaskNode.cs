using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskNode : Node
{
    private Blackboard _blackbboard;

    public TaskNode(Blackboard i_Blackbboard)
    {
        _blackbboard = i_Blackbboard;
        if (_blackbboard == null)
        {
            Debug.Log("blackboard data is null!");
        }
    }

    public object GetData(string i_Key)
    {
        object obj = _blackbboard.GetData(i_Key);
        if (obj != null)
        {
            return obj;
        }
        else
        {
            Debug.Log("Obj data is null!");
            return null;
        }
    }

    public void SetData(string i_Key, object i_Obj)
    {
        _blackbboard.SetData(i_Key, i_Obj);
    }
}
