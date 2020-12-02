using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using System;
using System.IO;

public class FileControl : MonoBehaviour
{
    public void LoadImageDialog()
    {
        StartCoroutine(GetTexture(OpenFileName.ShowDialog()));
    }
    public void LoadImage(string url)
    {
        StartCoroutine(GetTexture(url));

        //GetTexture(url);
    }

    public IEnumerator GetTexture(String url)
    {
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);


        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ここは->" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));

            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;   
            this.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", myTexture);
            Debug.Log("Collect Attach image");
        }
    }

    public IEnumerator SetTexture(GameObject obj, String url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            obj.GetComponent<Renderer>().material.SetTexture("_MainTex", myTexture);
            Debug.Log("Collect Attach image");
        }
    }

    public void Attachiimage(GameObject obj, string url)
    {
        StartCoroutine(SetTexture(obj, url));
    }
}