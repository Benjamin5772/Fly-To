using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Blackboard : MonoBehaviour
    {
        private Dictionary<string, object> dataContent = new Dictionary<string, object>();

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

            return null;
        }

        public bool ClearData(string key)
        {
            if (dataContent.ContainsKey(key))
            {
                dataContent.Remove(key);
                return true;
            }

            return false;
        }
    }
}

