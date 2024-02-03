using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Character player;
    private PlayerState playerStateChecker;
    private PlayerState playerState;

    [SerializeField]
    private ViewPoint viewPoint;

    [SerializeField] private Transform followingTarget;

    private void Awake()
    {
        player = GetComponent<Character>();
        playerState = GetComponent<PlayerState>();

        viewPoint.InitCamera(followingTarget);
    }

 
    void Start()
    {

    }


    void Update()
    {
        UpdateMovementInput();
        //UpdateStateInput();
        // 更新角色的旋转以匹配视角的偏航角
        player.RotateCharacter(viewPoint.Yaw);



    }

    //角色移动输入
    private void UpdateMovementInput()
    {
        //rotation input data
        Quaternion rot = Quaternion.Euler(0, viewPoint.Yaw, 0);

        //move
        if (!playerState.GivePushForce)
        {
            player.SetMovementInput(rot * Vector3.forward * Input.GetAxis("Vertical") +
                                    rot * Vector3.right * Input.GetAxis("Horizontal"));
        }
        else
        {
            player.SetMovementInput(rot * Vector3.forward * playerState.ForwardForce +
                                  rot * Vector3.right * Input.GetAxis("Horizontal"));
        }

        //up
        if (!playerState.GiveUpForce)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                player.RiseUp();
            }
        }
        else
        {
            player.FlyInAir(player, playerState.targetHeight, playerState.heightAdjustmentForce);
        }
        
        //update camera move
        viewPoint.UpdateRotation();
        viewPoint.UpdatePosition();
        
    }

    //角色状态输入
    private void UpdateStateInput()
    {
        playerStateChecker.CheckState();
    }


}