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
    public float MaxUpForce = 4; // 上升最大力量(手动)
    public float targetHeight = 1f;//目标高度（自动）
    public float heightAdjustmentForce = 1f;//高度调整（自动）

    // forward force
    public bool GivePushForce = false ;
    public float ForwardForce = 0.2f;

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
