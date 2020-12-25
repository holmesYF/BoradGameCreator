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
        if (ImageURL1 != null)
        {
            File.Copy(ImageURL1, Path.Combine(path, ControlString.CutTextAfter(ImageURL1, '\\')));
        }
        if (ImageURL2 != null)
        {
            File.Copy(ImageURL2, Path.Combine(path, ControlString.CutTextAfter(ImageURL2, '\\')));
        }
    }
}
