using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EventEnemy : MonoBehaviour
{
    public PlayableDirector playableDirector; 
    public GameObject triggerObject; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == triggerObject)
            {
                playableDirector.Play();
                Debug.Log("Trigger detected.");//¼ì²â²»µ½£¿
            }
        }
    }

}
