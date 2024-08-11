using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnityWebRequestImageLoader :MonoBehaviour
{
    public static UnityWebRequestImageLoader Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public Sprite GetImageFromURL(string url)
    {
        Sprite sprite = null;

        StartCoroutine(LoadAndGetImage(url, (returnValue) =>
        {
            sprite = returnValue;
        }));

        return sprite;
    }

    private IEnumerator LoadAndGetImage(string path, Action<Sprite> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            callback(null);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            callback(newSprite);
        }
    }
}
