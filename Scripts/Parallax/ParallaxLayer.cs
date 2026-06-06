using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ParallaxLayer 
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxMultiplier;
    [SerializeField] private float imageWidthOffset = 10;

    private float imageFullWidth;
    private float imageHalfWidth;

    public void CaculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }
    public void Move(float distanceToMove)
    {
        background.position += Vector3.right *(distanceToMove * parallaxMultiplier); //右的距离（即X轴）将由distanceToMove * parallaxMultiplier决定
    }

    public void LoopBackground(float cameraLeftWidth , float cameraRightWidth)
    {
        float imageLeftWidth = (background.position.x - imageHalfWidth)+imageWidthOffset;
        float imageRightWidth = (background.position.x + imageHalfWidth)-imageWidthOffset;

        if (imageRightWidth < cameraLeftWidth)
            background.position += Vector3.right * imageFullWidth;
        else if (imageLeftWidth > imageRightWidth)
            background.position += Vector3.right * -imageFullWidth;
    }
}
