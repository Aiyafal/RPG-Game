using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera mainCamera;
    private float lastCameraPosition;
    private float cameraHalfWidth;

    
    [SerializeField] private ParallaxLayer[] backgroundLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;  //orthographicSize是相机高度的一半， aspect是宽高比，相乘得宽度的一半    
        InitializeLayers();
    }

    private void FixedUpdate()
    {
        float currentCameraPosition = mainCamera.transform.position.x;
        float distanceToMove = currentCameraPosition - lastCameraPosition;
        lastCameraPosition = currentCameraPosition;

        float cameraLeftWidth = currentCameraPosition - cameraHalfWidth;
        float cameraRightWidth = currentCameraPosition + cameraHalfWidth;

        foreach (ParallaxLayer layer in backgroundLayers)
        {
            layer.Move(distanceToMove);
            layer.LoopBackground(cameraLeftWidth, cameraRightWidth);
        }

    }
    private void InitializeLayers()
    {
        foreach (ParallaxLayer layer in backgroundLayers)
            layer.CaculateImageWidth();
    }
}
