using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Character player = new Character();
    //private PlayerState playerStateChecker;
    private PlayerState playerState = new PlayerState();

    private Transform m_Transform;


    [SerializeField] private Transform followingTarget;

    private bool IsGameStart = false;

    // Camera
    //抬升(x轴)
    public float Pitch { get; private set; }
    //环视(y轴)
    public float Yaw { get; private set; }

    private void Awake()
    {
 
        m_Transform = GetComponent<Transform>();

        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        player.Init(playerRigidbody, playerState);
    }

 
    void Start()
    {
    
    }

    public void OnGameStart()
    {
        IsGameStart = true;
        //playerState.OnGameStart();
        player.OnGameStart();
    }


    void Update()
    {
        if (IsGameStart)
        {
            UpdateMovementInput();
        }
            
        //UpdateStateInput();
    }

    private void FixedUpdate()
    {
        if (IsGameStart)
        {
            player.MoveUpdate();
            // 更新角色的旋转以匹配视角的偏航角
            player.RotateCharacter(Yaw);
        }
    }

    //角色移动输入
    private void UpdateMovementInput()
    {
        //rotation input data
        Quaternion rot = Quaternion.Euler(0, Yaw, 0);

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
            player.FlyInAir(m_Transform, playerState.targetHeight, playerState.heightAdjustmentForce);
            
            if (playerState.CurrentFuel > 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    player.RiseUp();
                }
            }
        }

        //鼠标控制
        Yaw += Input.GetAxis("Mouse X");
        Pitch += Input.GetAxis("Mouse Y");//乘-1翻转y轴旋转
        //手柄控制
        Yaw += Input.GetAxis("CameraRateX");
        Pitch += Input.GetAxis("CameraRateY");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.GamePauseAndReleaseFuntion();
        }
        
    }

    //角色状态输入
    //private void UpdateStateInput()
    //{
        //playerStateChecker.CheckState();
    //}

    public void ApplyDamage(float i_Damage)
    {
        playerState.Hurt(i_Damage);
        GameManager.Instance.UpdateHealth();
    }

    public void GetProp()
    {
        //TODO
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }
}