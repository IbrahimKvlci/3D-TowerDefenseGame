using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize:MonoBehaviour
{
    private static float _screenHeight;
    private static float _screenWidth;



    private void Awake()
    {
        _screenHeight = 2 * Camera.main.orthographicSize;
        _screenWidth = _screenHeight * Camera.main.aspect;

    }

    public static float GetScreenHeight()
    {
        return _screenHeight;
    }

    public static float GetScreenWidth()
    {
        return _screenWidth;
    }


}
