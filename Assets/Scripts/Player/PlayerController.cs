using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Character player;
    private PlayerState playerStateChecker;

    [SerializeField]
    private ViewPoint viewPoint;

    [SerializeField] private Transform followingTarget;

    private void Awake()
    {
        player = GetComponent<Character>();

        viewPoint.InitCamera(followingTarget);
    }

 
    void Start()
    {

    }


    void Update()
    {
        UpdateMovementInput();
        //UpdateStateInput();


    }

    //角色操作输入
    private void UpdateMovementInput()
    {
        //旋转参数
        Quaternion rot = Quaternion.Euler(0, viewPoint.Yaw, 0);

        //移动
        player.SetMovementInput(rot * Vector3.forward * Input.GetAxis("Vertical") +
                                rot * Vector3.right * Input.GetAxis("Horizontal"));

        //上升
        if (Input.GetKey(KeyCode.Space))
        {

            player.RiseUp();
        }

        //todo 摄像机旋转和抬升



    }

    //角色状态输入
    private void UpdateStateInput()
    {
        playerStateChecker.CheckState();
    }


}