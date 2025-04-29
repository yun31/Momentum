using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.XR.CoreUtils;

public class CameraAlignerBrain : MonoBehaviour
{
    public XROrigin xrOrigin;
    public CinemachineBrain cinemachineBrain;
    public float smoothTime = 0.1f; // (����) �ε巯�� ���� ����

    void Update()
    {
        if (cinemachineBrain == null || cinemachineBrain.ActiveVirtualCamera == null)
            return;

        // ���� Ȱ��ȭ�� Virtual Camera ��������
        Transform activeCam = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.transform;

        // forward ���� ��������
        Vector3 targetForward = activeCam.forward;
        targetForward.Normalize();

        // XR Origin ȸ����Ű��
        Quaternion targetRotation = Quaternion.LookRotation(targetForward, Vector3.up);
        xrOrigin.transform.rotation = targetRotation;
    }
}
