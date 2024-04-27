using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerInGameUI :BaseWidget
{
    public PlayerState playerState = new PlayerState();  
    public GameObject healthIconPrefab;  
    public Transform canvasTransform; 
    
    private List<GameObject> healthIcons = new List<GameObject>();

    void Start()
    {
        if (playerState != null)
        {
            for (int i = 0; i < playerState.MaxHealth; i++)
            {
                GameObject icon = Instantiate(healthIconPrefab, canvasTransform);
                icon.SetActive(true);
                healthIcons.Add(icon);
            }
        }
    }

    void Update()
    {
    
        for (int i = 0; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(i < playerState.CurrentHealth);
        }
    }
}