using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlString : MonoBehaviour
{
    static private string s;
    //第１引数に指定した文字列の一番最後に現れる第２引数に指定した文字以降の文字列のみを返す
    public static string CutText(string str, char c)
    {
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
}
