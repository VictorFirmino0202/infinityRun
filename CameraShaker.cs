using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    [Header("Camera Shaker Config")]
    private Vector3 cameraInicialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;
    public Camera mainCamera;

    public void ShakeIt()
    {
        cameraInicialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShake", 0f, 0.005f);
        Invoke("StopCameraShake", shakeTime);
    }

    void StartCameraShake()
    {
        float cameraShakeOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakeOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;

        cameraIntermediatePosition.x += cameraShakeOffsetX;
        cameraIntermediatePosition.y += cameraShakeOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShake()
    {
        CancelInvoke("StartCameraShake");
        mainCamera.transform.position = cameraInicialPosition;
    }
}
