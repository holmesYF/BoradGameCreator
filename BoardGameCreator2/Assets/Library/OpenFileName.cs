using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200000F RID: 15
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenFileName
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public string filter = null;
    public string customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public string file = null;
    public int maxFile = 0;
    public string fileTitle = null;
    public int maxFileTitle = 0;
    public string initialDir = null;
    public string title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public string defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public string templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;
    public static readonly int OFN_ALLOWMULTISELECT = 512;
    public static readonly int OFN_CREATEPROMPT = 512;
    public static readonly int OFN_DONTADDTORECENT = 33554432;
    public static readonly int OFN_ENABLEHOOK = 32;
    public static readonly int OFN_ENABLEINCLUDENOTIFY = 4194304;
    public static readonly int OFN_ENABLESIZING = 8388608;
    public static readonly int OFN_ENABLETEMPLATE = 64;
    public static readonly int OFN_ENABLETEMPLATEHANDLE = 128;
    public static readonly int OFN_EXPLORER = 524288;
    public static readonly int OFN_EXTENSIONDIFFERENT = 1024;
    public static readonly int OFN_FILEMUSTEXIST = 4096;
    public static readonly int OFN_FORCESHOWHIDDEN = 268435456;
    public static readonly int OFN_HIDEREADONLY = 4;
    public static readonly int OFN_LONGNAMES = 2097152;
    public static readonly int OFN_NOCHANGEDIR = 8;
    public static readonly int OFN_NODEREFERENCELINKS = 1048576;
    public static readonly int OFN_NOLONGNAMES = 262144;
    public static readonly int OFN_NONETWORKBUTTON = 131072;
    public static readonly int OFN_NOREADONLYRETURN = 32768;
    public static readonly int OFN_NOTESTFILECREATE = 65536;
    public static readonly int OFN_NOVALIDATE = 256;
    public static readonly int OFN_OVERWRITEPROMPT = 2;
    public static readonly int OFN_PATHMUSTEXIST = 2048;
    public static readonly int OFN_READONLY = 1;
    public static readonly int OFN_SHAREAWARE = 16384;
    public static readonly int OFN_SHOWHELP = 16;

    public OpenFileName()
    {
        this.structSize = Marshal.SizeOf<OpenFileName>(this);
        this.filter = "All Files\0*.*\0\0";
        this.file = new string('\0', 4096);
        this.maxFile = this.file.Length;
        this.fileTitle = new string('\0', 256);
        this.maxFileTitle = this.fileTitle.Length;
        this.title = "Open";
        this.flags = (OpenFileName.OFN_EXPLORER | OpenFileName.OFN_FILEMUSTEXIST | OpenFileName.OFN_PATHMUSTEXIST | OpenFileName.OFN_NOCHANGEDIR);
    }

    // Token: 0x06000043 RID: 67
    [DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
    public static extern bool GetOpenFileName([In] [Out] OpenFileName lpOfn);


    public static string ShowDialog()
    {
        OpenFileName ofn = new OpenFileName();
        bool openFileName = OpenFileName.GetOpenFileName(ofn);
        string result;
        if (openFileName)
        {
            result = ofn.file;
        }
        else
        {
            result = null;
        }
        return result;
    }


    public static string[] GetFileName(string folder)
    {
        string[] names;
        try
        {
            names = Directory.GetFiles(folder, "*");
            foreach (string name in names)
            {
                Debug.Log(name);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            names = null;
        }
        return names;
    }

    
}
