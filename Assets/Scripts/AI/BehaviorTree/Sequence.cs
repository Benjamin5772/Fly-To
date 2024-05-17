using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Check()
        {
            // 如果有一个子节点在RUNNING，则表示这个Sequnce在RUNNING，应该返回RUNNING；
            bool IsThereAnyChildIsRunning = false;

            foreach (Node node in children) 
            {
                switch (node.Check())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        IsThereAnyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = IsThereAnyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
}

