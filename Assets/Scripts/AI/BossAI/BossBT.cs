using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossBT : BehaviorTree.Tree
{
    // 静态数据
    //public static float speed = 10.0f;

    public float BossPhaseOneShootDuration = 5.0f;
    public float BossPhaseTwoShootDuration = 3.0f;

    public GameObject FurballRef;

    protected override BehaviorTree.Node SetupTree()
    {
        _blackboard.SetData("BossPhase", 1);
        PlayerController m_PlayerController = GameManager.Instance.m_PlayerController;
        _blackboard.SetData("PlayerRef", m_PlayerController);
        _blackboard.SetData("BossWakeUp", false);

        BehaviorTree.Node node = new Sequence(new List<BehaviorTree.Node>
        {
            new CheckIfBossWakeUp(_blackboard),
            new Selector(new List<BehaviorTree.Node>
            {
                new Sequence(new List<BehaviorTree.Node>
                {
                    new CheckIfBossPhaseMatch(_blackboard, 1),
                    new FollowPlayer(_blackboard, transform),
                    new CheckIfCanShoot(_blackboard, BossPhaseOneShootDuration),
                    new Shoot(_blackboard, FurballRef, 1)
                }),
                new Sequence(new List<BehaviorTree.Node>
                {
                    new CheckIfBossPhaseMatch(_blackboard, 2),
                    new FollowPlayer(_blackboard, transform),
                    new CheckIfCanShoot(_blackboard, BossPhaseTwoShootDuration),
                    new Shoot(_blackboard, FurballRef, 2)
                })
            })
        });

        return node;
    }

    public void WakeUpBoss()
    {
        _blackboard.SetData("BossWakeUp", true);
    }
}
