using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize:MonoBehaviour
{
    private static float screenHeight;
    private static float screenWidth;

    private static float screenWidthPixel;
    private static float screenHeightPixel;

    private void Awake()
    {
        screenHeight = 2 * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

    }

    public static float GetScreenHeight()
    {
        return screenHeight;
    }

    public static float GetScreenWidth()
    {
        return screenWidth;
    }


}
