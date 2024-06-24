using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node root = null;

        protected Blackboard _blackboard = null;

        protected void Start()
        {
            _blackboard = GetComponent<Blackboard>();
            root = SetupTree();
        }

        private void Update()
        {
            if (root != null)
            {
                root.Check();
            }
        }

        protected abstract Node SetupTree();
    }
}

