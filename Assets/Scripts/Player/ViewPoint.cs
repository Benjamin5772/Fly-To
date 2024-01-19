using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewPoint : MonoBehaviour
{
    //抬升(x轴)
    public float Pitch { get; private set; }
    //环视(y轴)
    public float Yaw { get; private set; }

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
        UpdateRotation();
        UpdatePosition();
    }


    //摄像机跟随
    public void InitCamera(Transform target)
    {
        Target = target;
        transform.position = target.position;
    }



    //更新视角旋转
    private void UpdateRotation()
    {
        //鼠标控制
        Yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity * -1;//乘-1翻转y轴旋转
        //手柄控制
        Yaw += Input.GetAxis("CameraRateX") * cameraRotatingSpeed * Time.deltaTime;
        Pitch += Input.GetAxis("CameraRateY") * cameraRotatingSpeed * Time.deltaTime;
        //抬升视角限制
        Pitch = Mathf.Clamp(Pitch, 0, 45);
        //水平视角限制
        Yaw = Math.Clamp(Yaw, -30, 30);

        transform.rotation = Quaternion.Euler(Pitch, Yaw, 0);
    }

   
    private void UpdatePosition()
    {
        Vector3 position = Target.position;
        //动态跟随(Y轴)
        float newY = Mathf.Lerp(transform.position.y, position.y, Time.deltaTime * cameraYSpeed);
        //严格跟随（X轴)
        transform.position = new Vector3(position.x, newY, position.z);
    }

}
