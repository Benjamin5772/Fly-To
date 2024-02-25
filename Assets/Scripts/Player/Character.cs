using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character
{
    private Rigidbody playerRigidbody;
    private PlayerState playerState;

    // VFX
    // TODO

    //获取输入
    public Vector3 CurrentInput { get; private set; }
 
    public void Init(Rigidbody i_Rig, PlayerState i_PS)
    {
        playerRigidbody = i_Rig;
        playerState = i_PS;
    }

    public void MoveUpdate()
    {
        //移动到playercontroller
        Move();
    }

 

    public void SetMovementInput(Vector3 input)
    {
        //输入限制到1
        CurrentInput = Vector3.ClampMagnitude(input, 1);
    }

    
    public void Move()
    {
        //将rb移动到目标位置
        playerRigidbody.MovePosition(playerRigidbody.position + CurrentInput * playerState.MaxWalkSpeed * Time.fixedDeltaTime);
    }

    public void RiseUp()
    {
        // 计算上升力
        float upForceStrength = UnityEngine.Random.Range(playerState.MinUpForce, playerState.MaxUpForce);
        Vector3 upForce = playerState.RiseUpDirection * upForceStrength;

        playerRigidbody.AddForce(upForce);

    }


    public void FlyInAir(Transform playerTrans,float targetHeight,float heightAdjustmentForce)
    {
        // 计算上升力
        float heightDifference = targetHeight - playerTrans.transform.position.y;  // 计算高度差
        float upForce = 9.81f * playerRigidbody.mass;  // 基础漂浮力，抵消重力

        // 根据高度差调整额外的力，简单的P控制器
        float adjustmentForce = heightDifference * heightAdjustmentForce;

        // 应用总力
        playerRigidbody.AddForce(Vector3.up * (upForce + adjustmentForce));
    }


    public void RotateCharacter(float yaw)
    {
        // 将角色的旋转设置为当前视角的偏航角，但保持角色的倾斜角度不变
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);
        playerRigidbody.MoveRotation(rotation);
    }


    //public void ApplyEffect(i_EffectType Effect_Type)
    //

    //}

}
