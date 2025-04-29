using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.XR.CoreUtils;

public class CameraAlignerBrain : MonoBehaviour
{
    public XROrigin xrOrigin;
    public CinemachineBrain cinemachineBrain;
    public float smoothTime = 0.1f; // (선택) 부드러운 정도 조정

    void Update()
    {
        if (cinemachineBrain == null || cinemachineBrain.ActiveVirtualCamera == null)
            return;

        // 현재 활성화된 Virtual Camera 가져오기
        Transform activeCam = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.transform;

        // forward 방향 가져오기
        Vector3 targetForward = activeCam.forward;
        targetForward.Normalize();

        // XR Origin 회전시키기
        Quaternion targetRotation = Quaternion.LookRotation(targetForward, Vector3.up);
        xrOrigin.transform.rotation = targetRotation;
    }
}
