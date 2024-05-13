using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    // move data
    public float MaxWalkSpeed = 5;

    // up force data
    public bool GiveUpForce = true;
    public Vector3 RiseUpDirection = Vector3.up; // 风向
    public float MinUpForce = 2; // 上升最小力量(手动)
    public float MaxUpForce = 2.0f; // 上升最大力量(手动)
    // public float targetHeight = 1.4f;//目标高度（自动）
    public float targetHeight = 0.3f;//目标高度（自动）
    public float heightAdjustmentForce = 1.2f;//高度调整（自动）
   
    // forward force
    public bool GivePushForce = false ;
    public float ForwardForce = 0.04f;

    public float lateralMoveRange = 0.5f;  // 左右移动的最大范围
    public Vector3 movementAreaOffset = new Vector3(32, 0, 3.5f);  // 移动区域的偏移量
    // 血量
    public float MaxHealth = 3.0f;
    public float CurrentHealth = 3.0f;
    // 燃料
    public float MaxFuel = 100.0f;
    public float CurrentFuel = 100.0f;
    //受伤冷却
    private float hurtCooldown = 2.0f; // 冷却时间为2秒
    private float lastHurtTime = -2.0f;

    //花朵计数器
    private int flower_number = 0;

    public void OnGameStart()
    {
        GivePushForce = true;
        CurrentHealth = MaxHealth;
        flower_number = 0;
    }

    public void CheckState()
    {

    }

    public void Hurt(float damage)
    {
        if (Time.time >= lastHurtTime + hurtCooldown)
        {
            CurrentHealth -= damage;
            lastHurtTime = Time.time;
            Debug.Log("Player hurt. Current health: " + CurrentHealth);
        }
    }

    public void SpeedUp()
    {

    }

    public void AddFlower(int i_Number)
    {
        flower_number += i_Number;
        CheckFlower();
    }

    public void ForceSetFlower(int i_NewNumber)
    {
        flower_number = i_NewNumber;
    }

    private void CheckFlower()
    {
        if (flower_number >= 10)
        {
            flower_number -= 10;
            CurrentHealth += 1.0f;
            GameManager.Instance.UpdateHealth();
            CheckFlower();
        }
    }

    public int GetFlowerNumber()
    {
        return flower_number; 
    }
}
