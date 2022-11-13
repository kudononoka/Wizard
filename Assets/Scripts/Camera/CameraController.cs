using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour, InterfacePause
{
    CinemachineFreeLook _freeLook;
    void Start()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();
    }
    void InterfacePause.Pause()
    {
        _freeLook.m_XAxis.m_MaxSpeed = 0;
        _freeLook.m_YAxis.m_MaxSpeed = 0;
    }

    void InterfacePause.Resume()
    {
        _freeLook.m_XAxis.m_MaxSpeed = 1000;
        _freeLook.m_YAxis.m_MaxSpeed = 20;
    }
}
