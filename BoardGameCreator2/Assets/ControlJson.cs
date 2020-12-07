using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ControlJson
{
    static private int IDnum;
    static private string path;

    static public void OutPutJson(string json)
    {
        do
        {
            path = @"./" + IDnum.ToString() + @".json";
            IDnum += 1;
        }
        while (File.Exists(path));
        _OutPutJson(json, path);
    }
    static public void OutPutJson(string json, string url)
    {
        do
        {
            path = url + @"\" + IDnum.ToString() + @".json";
            IDnum += 1;
        }
        while (File.Exists(path));
        _OutPutJson(json, path);
    }
    /// <summary>
    /// 第一引数にjsonにしたいstringのリストを渡す
    /// </summary>
    /// <param name="list"></param>
    /// <param name="url"></param>
    static public void ListOutPutJson(List<string> list,string url)
    {
        list.ForEach(json =>
        {
            OutPutJson(json,url);

        });
    }

    static private void _OutPutJson(string json, string path)
    {
        try
        {
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(json);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            Debug.Log("CreateFile to " + path);
            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Debug.Log("exports=>path:" + path);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }




    static public List<string> LoadJson(string path)
    {
        string[] JsonsPath = Directory.GetFiles(path, "*");
        string json;
        List<string> datas = new List<string>();
        foreach (string JsonPath in JsonsPath)
        {
            if (JsonPath.Contains(@".json"))
            {
                StreamReader sr = File.OpenText(JsonPath);
                json = sr.ReadLine();
                //datas.Add(JsonUtility.FromJson<_Data>(json));
                datas.Add(json);
                Debug.Log("Add data List");
            }
        }
        return datas;
    }
}
