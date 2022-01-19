using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private CinemachineFreeLook vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineFreeLook>();
    }

    public void TrackPlayer (Transform transform)
    {
        vcam.Follow = transform;
        vcam.LookAt = transform;
    }
}
