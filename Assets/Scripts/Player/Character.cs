using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour

{
    private Rigidbody playerRigidbody;
    private PlayerState playerState;

    //获取输入
    public Vector3 CurrentInput { get; private set; }
    public float MaxWalkSpeed = 5;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
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
        playerRigidbody.MovePosition(playerRigidbody.position + CurrentInput * MaxWalkSpeed * Time.fixedDeltaTime);
    }

    public void RiseUp()
    {
        // 计算上升力
        float upForceStrength = UnityEngine.Random.Range(playerState.MinUpForce, playerState.MaxUpForce);
        Vector3 upForce = playerState.RiseUpDirection * upForceStrength;

        playerRigidbody.AddForce(upForce);
    }

   

}
