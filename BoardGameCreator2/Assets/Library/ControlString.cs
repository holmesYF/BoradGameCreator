using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlString : MonoBehaviour
{
    
    static private string s;
    //第１引数に指定した文字列の一番最後に現れる第２引数に指定した文字以降の文字列のみを返す
    /// <summary>
    /// <c>CutText</c>は第１引数に指定した文字列の一番最後に現れる第２引数に指定した文字以降の文字列のみを返す
    /// </summary>
    /// <param name="str">編集文字列</param>
    /// <param name="c">カット指定文字列</param>
    /// <returns></returns>
    public static string CutTextAfter(string str, char c)
    {
        if(str == null)
        {
            Debug.LogError("CutText Error Null:" + str);
            return null;
        }
        s = "";
        foreach (char ch in str)
        {
            if (ch == c)
            {
                s = null;
            }
            else
            {
                s += ch;
            }
        }
        return s;
    }

    public static string CutTextBefore(string str,char c)
    {
        if (str == null)
        {
            Debug.LogError("CutText Error Null:" + str);
            return null;
        }
        s = "";
        foreach (char ch in str)
        {
            if (ch == c)
            {
                return s;
            }
            else
            {
                s += ch;
            }
        }
        return s;
    }
}
