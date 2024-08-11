using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImageLoader
{
    Sprite GetImageFromURL(string url);
}
