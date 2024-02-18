using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewPoint : MonoBehaviour
{
    //抬升(x轴)
    //public float Pitch { get; private set; }
    //环视(y轴)
    //public float Yaw { get; private set; }

    //鼠标灵敏
    public float mouseSensitivity = 5;

    public float cameraRotatingSpeed = 80;
    public float cameraYSpeed = 5;
    private Transform Target;

    private void Awake()
    {
      
    }

    void Start()
    {

    }

    //删
    void Update()
    {
       //UpdateRotation();
       // UpdatePosition();
    }


    //摄像机跟随
    public void InitCamera(Transform target)
    {
        Target = target;
        transform.position = target.position;
    }

    //更新视角旋转
    public void UpdateRotation(float i_Yaw, float i_Pitch)
    {
        // 计算灵敏度
        i_Yaw *= mouseSensitivity;
        i_Pitch *= mouseSensitivity * -1;//乘-1翻转y轴旋转
        //手柄控制
        //Yaw += Input.GetAxis("CameraRateX") * cameraRotatingSpeed * Time.deltaTime;
        //Pitch += Input.GetAxis("CameraRateY") * cameraRotatingSpeed * Time.deltaTime;
        //抬升视角限制
        i_Pitch = Mathf.Clamp(i_Pitch, 0, 45);
        //水平视角限制
        i_Yaw = Math.Clamp(i_Yaw, -30, 30);

        transform.rotation = Quaternion.Euler(i_Pitch, i_Yaw, 0);
    }

   
    public void UpdatePosition()
    {
        Vector3 position = Target.position;
        //动态跟随(Y轴)
        float newY = Mathf.Lerp(transform.position.y, position.y, Time.deltaTime * cameraYSpeed);
        //严格跟随（X轴)
        transform.position = new Vector3(position.x, newY, position.z);
    }

}
