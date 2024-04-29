using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerState playerState = new PlayerState();

    // VFX
    // TODO

    //获取输入
    public Vector3 CurrentInput { get; private set; }

    public Camera mainCamera;

    public void Init(Rigidbody i_Rig, PlayerState i_PS)
    {
        playerRigidbody = i_Rig;
        playerState = i_PS;
        playerRigidbody.useGravity = false;
        // 设置 Rigidbody 的初始位置为当前 Transform 的位置
       // playerRigidbody.position = transform.position;

    }

    public void OnGameStart()
    {
        playerRigidbody.useGravity = true;
        playerState.OnGameStart();
    }

    public void MoveUpdate()
    {
        //移动到playercontroller
        Move();
    }

    public void SetMovementInput(Vector3 input)
    {
        //输入限制到1
        CurrentInput = Vector3.ClampMagnitude(input,1);
    }

    
    public void Move()
    {
        Vector3 movement = CurrentInput * playerState.MaxWalkSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = playerRigidbody.position + movement;

        // 应用偏移和范围限制
        float minX = -playerState.lateralMoveRange + playerState.movementAreaOffset.x;
        float maxX = playerState.lateralMoveRange + playerState.movementAreaOffset.x;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        playerRigidbody.MovePosition(newPosition);

        //移动到边缘后会随着边缘滑行

    }

    public void RiseUp()
    {
        // 计算上升力
        float upForceStrength = UnityEngine.Random.Range(playerState.MinUpForce, playerState.MaxUpForce)* 0.1f;
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


    void OnDrawGizmos()
    {
        if (playerState == null)
            return;

        Gizmos.color = Color.red;
        // 使用偏移更新中心位置
        Vector3 center = new Vector3(0, 1, 0) + playerState.movementAreaOffset;
        float width = playerState.lateralMoveRange * 2;
        float height = 3;
        Gizmos.DrawWireCube(center, new Vector3(width, height, 0.1f));
    }


}
