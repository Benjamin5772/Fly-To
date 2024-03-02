using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : BaseWidget
{

    public Camera targetCamera;
    public GameObject inGameMenuObject;
    public GameObject gameStartUI;
    public GameObject inGameUI;

    private Vector3 originalPosition;
    private Quaternion originalRotation;



    // Start is called before the first frame update
    void Start()
    {
        // 存储摄像头的原始位置和旋转角度
        if (targetCamera != null)
        {
            originalPosition = targetCamera.transform.position;
            originalRotation = targetCamera.transform.rotation;
        }

        // 默认隐藏菜单
        inGameMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 监听ESC键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inGameMenuObject.SetActive(!inGameMenuObject.activeSelf);
        }

    }

      public void ResetCameraPositionAndRotation()
    {
        // 检查是否设置了目标摄像头
        if (targetCamera != null)
        {
            // 将摄像头复原到原始位置和旋转角度
            targetCamera.transform.position = originalPosition;
            targetCamera.transform.rotation = originalRotation;

            //将除了主菜单外的都隐藏
            if (inGameMenuObject != null) inGameMenuObject.SetActive(false);
            if (gameStartUI != null) gameStartUI.SetActive(true);
            if (inGameUI != null) inGameUI.SetActive(false);
        }
    }
}
