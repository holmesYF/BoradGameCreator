using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageName : MonoBehaviour
{
    public string ImageURL1 = null;
    public string ImageURL2 = null;
    public void MoveImage(string path)
    {
        Debug.LogError(Path.Combine(path, ControlString.CutTextAfter(ImageURL1, '\\')));
        if (ImageURL1 != ""&& ImageURL1 != null && !File.Exists(Path.Combine(path, ControlString.CutTextAfter(ImageURL1, '\\'))))
        {
            File.Copy(ImageURL1, Path.Combine(path, ControlString.CutTextAfter(ImageURL1, '\\')));
        }
        if (ImageURL2 != "" && ImageURL2 != null && !File.Exists(Path.Combine(path, ControlString.CutTextAfter(ImageURL2, '\\'))))
        {
            File.Copy(ImageURL2, Path.Combine(path, ControlString.CutTextAfter(ImageURL2, '\\')));
        }
    }
}
