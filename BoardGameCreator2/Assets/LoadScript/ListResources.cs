using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ListResources : MonoBehaviour
{
    /*void Start()
    {
        GameObject ResoucesList = GameObject.Find("ResoucesList");
        GameObject Viewport = ResoucesList.transform.FindChild("Viewport").gameObject;
    }*/
    public GameObject Content;
    public GameObject DataNode;//= GameObject.Find("DataNode");
    GameObject Obj;
    public GameObject Text;
    public GameObject LoadObject;

    public static string[] get_folder_name(string folder)
    {
        string[] names = null;
        try
        {
            names = Directory.GetDirectories(folder, "*");
            foreach (string name in names)
            {
                Debug.Log(name);
            }
            Debug.Log(names);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            names = null;
        }
        return names;
    }

    public void make_list()
    {
#if UNITY_EDITOR
        string[] names = get_folder_name(@"C:\Users\holme\Desktop\もいっこ用\TableGameData");
#else
        Debug.LogError("adafsfwef");
        string[] names = get_folder_name(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),"TableGameData"));
#endif
        //Debug.LogError(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'), "TableGameData"));
        foreach (string name in names)
        {
            GameObject Obj = (GameObject)Instantiate(DataNode, this.transform.position, Quaternion.identity);
            Obj.transform.parent = Content.transform;
            Obj.transform.Find("FolderName").GetComponent<Text>().text = ControlString.CutTextAfter(name,'\\');
            Obj.GetComponent<Content>().LoadManager = this.gameObject;
        }
    }
}



