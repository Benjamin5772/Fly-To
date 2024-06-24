using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        public Node() 
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children) 
            {
                AttachNode(child);
            }
        }

        private void AttachNode(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Check() => NodeState.FAILURE;
    }
}


