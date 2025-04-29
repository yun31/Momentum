using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils; // XR Origin ���� �� �ʿ�!

public class AlignCameraToUser : MonoBehaviour
{
    public XROrigin xrOrigin; // XR Origin�� �巡���ؼ� ���� �ž�.

    public void AlignForward()
    {
        // 1. ����� ���� �Ӹ� ȸ���� ��������
        Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);

        // 2. �� ���� ��� (Y�ุ ���)
        Vector3 forward = headRotation * Vector3.forward;
        forward.y = 0; // ���� ��� (���� ����)
        forward.Normalize();

        // 3. XR Origin�� ȸ�� ����
        Quaternion targetRotation = Quaternion.LookRotation(forward, Vector3.up);
        xrOrigin.transform.rotation = targetRotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        AlignForward();
    }

}
