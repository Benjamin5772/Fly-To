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
    public float targetHeight = 0.35f;//目标高度（自动）
    public float heightAdjustmentForce = 1.2f;//高度调整（自动）
   
    // forward force
    public bool GivePushForce = true ;
    public float ForwardForce = 0.04f;

    public float lateralMoveRange = 2f;  // 左右移动的最大范围
    public Vector3 movementAreaOffset = new Vector3(32, 0, 3.5f);  // 移动区域的偏移量
    // 血量
    // TODO

    public void CheckState()
    {

    }

    public void Hurt()
    {

    }

    public void SpeedUp()
    {

    }
}
