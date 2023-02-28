using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float defaultDistance = 3f;
    [SerializeField][Range(0f, 10f)] private float minDistance =1.5f;
    [SerializeField][Range(0f, 10f)] private float maxDistance =5f; 
    
    [SerializeField][Range(0f, 10f)] private float smoothing =4f;
    [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 1f;

    private float TargetDistance;
    private CinemachineFramingTransposer framingTransposer;
    private CinemachineInputProvider cinemachineInputProvider;
    private void Awake()
    {
        TargetDistance = defaultDistance;
        framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        cinemachineInputProvider = GetComponent<CinemachineInputProvider>();
    }

    private void Update()
    {
        zoom();
    }

    private void zoom()
    {
        float zoomvalue = cinemachineInputProvider.GetAxisValue(2) * zoomSensitivity;

        TargetDistance = Mathf.Clamp(TargetDistance + zoomvalue, minDistance, maxDistance);

        float currentDistance = framingTransposer.m_CameraDistance;

        if (currentDistance == TargetDistance)
            return;

        float LerpzoomValue = Mathf.Lerp(currentDistance,TargetDistance, smoothing*Time.deltaTime);
        framingTransposer.m_CameraDistance = LerpzoomValue;
    }
}
