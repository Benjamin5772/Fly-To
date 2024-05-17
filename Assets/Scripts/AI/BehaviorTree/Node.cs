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

        private Dictionary<string, object> dataContent = new Dictionary<string, object>();

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

        public void SetData(string key, object value)
        {
            dataContent[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (dataContent.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                {
                    return value;
                }
                node = node.parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if (dataContent.ContainsKey(key))
            {
                dataContent.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                {
                    return true;
                }
                node = node.parent;
            }

            return false;
        }
    }
}


