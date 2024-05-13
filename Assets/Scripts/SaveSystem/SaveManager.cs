using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string SaveData_Health = "Health";
    public string SaveData_SaveObjectID = "SaveObjectID";
    public string SaveData_FlowerNumber = "FlowerNumber";
}

public struct SaveDataStr
{
    public float Health;
    public int SaveObjectID;
    public int FlowerNumber;
}

public class SaveManager : Singleton<SaveManager>
{
    private SaveObject CurrentSO;
    private SaveData m_SaveData;

    private List<SaveObject> SaveObjects = new List<SaveObject>();

    private void Start()
    {
        CurrentSO = null;
        GameObject[] SaveObjects_OBJS = GameObject.FindGameObjectsWithTag("SaveObject");
        for (int i = 0; i < SaveObjects_OBJS.Length; i++)
        {
            SaveObject CurrSaveObj = SaveObjects_OBJS[i].GetComponent<SaveObject>();
            if (CurrSaveObj != null)
            {
                SaveObjects.Add(CurrSaveObj);
            }
        }
    }

    public void OnSave(SaveObject i_SO)
    {
        CurrentSO = i_SO;
    }

    public void OnLoad(PlayerController i_Controller)
    {
        i_Controller.ForceTeleport(CurrentSO.save_location);
    }

    public void LoadFromSaveData(int i_SaveObjectIndex, PlayerController i_Controller)
    {
        foreach (var obj in SaveObjects)
        {
            if (obj.SaveObjectID == i_SaveObjectIndex)
            {
                CurrentSO = obj;
                break;
            }
        }

        OnLoad(i_Controller); 
    }

    public void Cleaup()
    {
        CurrentSO = null;
    }

    public void SaveDataToLocal()
    {
        // 保存生命值
        float CurrentPlayerHealth = GameManager.Instance.GetPlayerHealth();
        PlayerPrefs.SetFloat(m_SaveData.SaveData_Health, CurrentPlayerHealth);
        // 保存SaveObject
        int CurrentSaveObjectIndex = -1;
        if (CurrentSO != null)
        {
            CurrentSaveObjectIndex = CurrentSO.SaveObjectID;
        }
        PlayerPrefs.SetInt(m_SaveData.SaveData_SaveObjectID, CurrentSaveObjectIndex);
        // 保存FlowerNumber
        int CurrentFlowerNumber = GameManager.Instance.GetPlayerFlowerNumber();
        PlayerPrefs.SetInt(m_SaveData.SaveData_FlowerNumber, CurrentFlowerNumber);
    }

    public void LoadLocalDataToGame()
    {
        // 读取生命值
        float CurrentPlayerHealth = PlayerPrefs.GetFloat(m_SaveData.SaveData_Health);
        // 读取SaveObject
        int CurrentSaveObjectIndex = PlayerPrefs.GetInt(m_SaveData.SaveData_SaveObjectID);
        // 读取FlowerNumber
        int CurrentFlowerNumber = PlayerPrefs.GetInt(m_SaveData.SaveData_FlowerNumber);

        SaveDataStr NewSaveStr = new SaveDataStr();
        NewSaveStr.Health = CurrentPlayerHealth;
        NewSaveStr.FlowerNumber = CurrentFlowerNumber;
        NewSaveStr.SaveObjectID = CurrentSaveObjectIndex;

        // Load game
        GameManager.Instance.OnGameReload(NewSaveStr);
    }
}
