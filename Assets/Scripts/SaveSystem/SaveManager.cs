using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private SaveObject CurrentSO;

    private void Start()
    {
        CurrentSO = null;
    }

    public void OnSave(SaveObject i_SO)
    {
        CurrentSO = i_SO;
    }

    public void OnLoad(PlayerController i_Controller)
    {
        i_Controller.ForceTeleport(CurrentSO.save_location);
    }

    public void Cleaup()
    {
        CurrentSO = null;
    }
}
