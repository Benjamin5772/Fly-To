using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseWidget
{
    // 开始游戏的按钮
    // 当点下这个按钮之后，调用开始游戏的接口

    public Camera mainMenuCamera;
    public GameObject rotatingObject; // 需要旋转的游戏物体
    public PlayerState playerState = new PlayerState();// Add reference to PlayerState
    public float screenMoveSpeed = 1.0f;
    public float cameraMoveTime = 1.5f;

    public Vector3 rotationAngle = new Vector3(0, 90, 0); // 可调的旋转角度

    public GameObject gameStartUI;
    public GameObject inGameUI;

    // Start is called before the first frame update
    void Start()
    {

        if (gameStartUI != null) gameStartUI.SetActive(true);
        if (inGameUI != null) inGameUI.SetActive(false);
       
      
    }

    void Update()
    {

    }

    public void OnGameStartButtonClicked()
    {
        // 通知Gamemanager开始游戏
        // TODO
        if (playerState != null)
        {
            playerState.GivePushForce = true;
        }


        //旋转摄像机
        StartCoroutine(RotateAndMoveCamera());
        //旋转物体
        if (rotatingObject != null)
        {
            StartCoroutine(RotateObject(rotatingObject, rotationAngle, cameraMoveTime));
        }

        if (gameStartUI != null) gameStartUI.SetActive(false);
        StartCoroutine(SwitchUIAfterDelay());
    }

    // 隐藏开始界面，打开游戏内ui
      private IEnumerator SwitchUIAfterDelay()
     {
        yield return new WaitForSeconds(cameraMoveTime);
        if (inGameUI != null) inGameUI.SetActive(true);
     }


    private IEnumerator RotateAndMoveCamera()
    {
        Quaternion originalRotation = mainMenuCamera.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(mainMenuCamera.transform.eulerAngles.x, mainMenuCamera.transform.eulerAngles.y + 90, mainMenuCamera.transform.eulerAngles.z);

        float elapsedTime = 0f;
        float duration = cameraMoveTime; // 旋转持续时间

        Vector3 rotationCenter = rotatingObject != null ? rotatingObject.transform.position : Vector3.zero;
     
        float rotationAmount = rotationAngle.y / cameraMoveTime;

        // 旋转过程
        while (elapsedTime < duration)
        {
            mainMenuCamera.transform.RotateAround(rotationCenter, Vector3.up, rotationAmount * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainMenuCamera.transform.rotation = targetRotation;

        // 移动摄像机
        while (true)
        {
            mainMenuCamera.transform.Translate(Vector3.forward * Time.deltaTime * screenMoveSpeed, Space.World);
            yield return null;
        }

    }
    // 旋转物体
    private IEnumerator RotateObject(GameObject obj, Vector3 angle, float duration)
    {
        Quaternion originalRotation = obj.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(obj.transform.eulerAngles + angle);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            obj.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = targetRotation;
    }

}