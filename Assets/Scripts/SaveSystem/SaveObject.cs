using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    public int SaveObjectID;
    public GameObject save_location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //1. 判断是否是玩家
        if (other.CompareTag("Player"))
        {
            Save();
        }
        //2. 如果是玩家，调用Save接口，如果不是，return
        else 
        {
           return;
        }

    }

    private void Save()
    {
        //1. 在全局保存一个index，能够找到在第几个save object处进行的保存，方便玩家回溯的时候，能够快速找到。
        SaveManager.Instance.OnSave(this);  
    }
}
