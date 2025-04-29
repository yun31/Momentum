using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils; // XR Origin 쓰는 데 필요!

public class AlignCameraToUser : MonoBehaviour
{
    public XROrigin xrOrigin; // XR Origin을 드래그해서 넣을 거야.

    public void AlignForward()
    {
        // 1. 사용자 현재 머리 회전값 가져오기
        Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);

        // 2. 앞 방향 계산 (Y축만 고려)
        Vector3 forward = headRotation * Vector3.forward;
        forward.y = 0; // 수평만 고려 (상하 무시)
        forward.Normalize();

        // 3. XR Origin의 회전 변경
        Quaternion targetRotation = Quaternion.LookRotation(forward, Vector3.up);
        xrOrigin.transform.rotation = targetRotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        AlignForward();
    }

}
