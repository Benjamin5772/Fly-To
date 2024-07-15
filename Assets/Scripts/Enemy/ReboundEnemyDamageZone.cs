using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ReboundEnemyDamageZone : MonoBehaviour
{
    private ReboundEnemy m_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parentObject = this.gameObject.transform.parent.gameObject;
        m_Enemy = parentObject.GetComponent<ReboundEnemy>();
        if (m_Enemy == null)
        {
            Debug.Log("ReboundEnemy is null!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            PlayerController tryPlayer = other.GetComponent<PlayerController>();
            if (tryPlayer != null)
            {
                // damage 玩家

            }
            BossBT tryBoss = other.GetComponent<BossBT>();
            if (tryBoss != null)
            {
                // damage boss

            }
        }
    }
}
