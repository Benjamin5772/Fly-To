using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameUI : BaseWidget
{
    public PlayerState playerState = new PlayerState();
    public GameObject healthIconPrefab;
    public Transform canvasTransform;
    public Slider fuelBar; 

    private List<GameObject> healthIcons = new List<GameObject>();
    private float iconSpacing = 150;  // Icon spacing
    private Vector2 initialPosition = new Vector2(-10, -10);  // Initial position of icons

    void Start()
    {
        InitializeHealthIcons();
        InitializeFuelBar();
    }

    void InitializeHealthIcons()
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

    void InitializeFuelBar()
    {
        if (fuelBar != null && playerState != null)
        {
            fuelBar.maxValue = playerState.MaxFuel;
            fuelBar.value = playerState.CurrentFuel;
        }
    }

    void Update()
    {
        UpdateHealthIcons();
        HandleFuelConsumption();
    }

    void UpdateHealthIcons()
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(i < playerState.CurrentHealth);
        }
    }

    void HandleFuelConsumption()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (playerState.CurrentFuel > 0)
            {
                playerState.CurrentFuel -= Time.deltaTime * 30;  // Fuel consumption rate
                fuelBar.value = playerState.CurrentFuel;
            }
        }
        else if (playerState.CurrentFuel < playerState.MaxFuel)
        {
            playerState.CurrentFuel += Time.deltaTime * 10;  // Fuel regeneration rate
            fuelBar.value = playerState.CurrentFuel;
        }
    }
}
