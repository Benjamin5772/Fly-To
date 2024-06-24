using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class BossBT : Tree
{
    // 静态数据
    //public static float speed = 10.0f;

    protected override Node SetupTree()
    {
        _blackboard.SetData("BossPhase", 1);
        Node node = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckIfBossPhaseOne(_blackboard)
            }),
            new Sequence() 
        });

        return node;
    }
}
