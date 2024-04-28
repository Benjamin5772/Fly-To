using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameUI : BaseWidget   
{
    public PlayerState playerState = new PlayerState();
    public GameObject healthIconPrefab;
    public Transform canvasTransform;

    private List<GameObject> healthIcons = new List<GameObject>();
    private float iconSpacing = 150;  // º‰æ‡
    private Vector2 initialPosition = new Vector2(-10, -10);  // ≥ı ºŒª÷√

    void Start()
    {
        if (playerState != null)
        {
            for (int i = 0; i < playerState.MaxHealth; i++)
            {
                GameObject icon = Instantiate(healthIconPrefab, canvasTransform);
                icon.SetActive(true);

                RectTransform rectTransform = icon.GetComponent<RectTransform>(); 
                if (rectTransform != null)
                {
                    rectTransform.anchorMin = new Vector2(1, 1);
                    rectTransform.anchorMax = new Vector2(1, 1);
                    rectTransform.pivot = new Vector2(1, 1);
                    rectTransform.anchoredPosition = new Vector2(initialPosition.x - i * iconSpacing, initialPosition.y);
                }

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
