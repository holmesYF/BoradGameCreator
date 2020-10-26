using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200000F RID: 15
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenFileName
{
    // Token: 0x04000019 RID: 25
    public int structSize = 0;

    // Token: 0x0400001A RID: 26
    public IntPtr dlgOwner = IntPtr.Zero;

    // Token: 0x0400001B RID: 27
    public IntPtr instance = IntPtr.Zero;

    // Token: 0x0400001C RID: 28
    public string filter = null;

    // Token: 0x0400001D RID: 29
    public string customFilter = null;

    // Token: 0x0400001E RID: 30
    public int maxCustFilter = 0;

    // Token: 0x0400001F RID: 31
    public int filterIndex = 0;

    // Token: 0x04000020 RID: 32
    public string file = null;

    // Token: 0x04000021 RID: 33
    public int maxFile = 0;

    // Token: 0x04000022 RID: 34
    public string fileTitle = null;

    // Token: 0x04000023 RID: 35
    public int maxFileTitle = 0;

    // Token: 0x04000024 RID: 36
    public string initialDir = null;

    // Token: 0x04000025 RID: 37
    public string title = null;

    // Token: 0x04000026 RID: 38
    public int flags = 0;

    // Token: 0x04000027 RID: 39
    public short fileOffset = 0;

    // Token: 0x04000028 RID: 40
    public short fileExtension = 0;

    // Token: 0x04000029 RID: 41
    public string defExt = null;

    // Token: 0x0400002A RID: 42
    public IntPtr custData = IntPtr.Zero;

    // Token: 0x0400002B RID: 43
    public IntPtr hook = IntPtr.Zero;

    // Token: 0x0400002C RID: 44
    public string templateName = null;

    // Token: 0x0400002D RID: 45
    public IntPtr reservedPtr = IntPtr.Zero;

    // Token: 0x0400002E RID: 46
    public int reservedInt = 0;

    // Token: 0x0400002F RID: 47
    public int flagsEx = 0;

    // Token: 0x04000030 RID: 48
    public static readonly int OFN_ALLOWMULTISELECT = 512;

    // Token: 0x04000031 RID: 49
    public static readonly int OFN_CREATEPROMPT = 512;

    // Token: 0x04000032 RID: 50
    public static readonly int OFN_DONTADDTORECENT = 33554432;

    // Token: 0x04000033 RID: 51
    public static readonly int OFN_ENABLEHOOK = 32;

    // Token: 0x04000034 RID: 52
    public static readonly int OFN_ENABLEINCLUDENOTIFY = 4194304;

    // Token: 0x04000035 RID: 53
    public static readonly int OFN_ENABLESIZING = 8388608;

    // Token: 0x04000036 RID: 54
    public static readonly int OFN_ENABLETEMPLATE = 64;

    // Token: 0x04000037 RID: 55
    public static readonly int OFN_ENABLETEMPLATEHANDLE = 128;

    // Token: 0x04000038 RID: 56
    public static readonly int OFN_EXPLORER = 524288;

    // Token: 0x04000039 RID: 57
    public static readonly int OFN_EXTENSIONDIFFERENT = 1024;

    // Token: 0x0400003A RID: 58
    public static readonly int OFN_FILEMUSTEXIST = 4096;

    // Token: 0x0400003B RID: 59
    public static readonly int OFN_FORCESHOWHIDDEN = 268435456;

    // Token: 0x0400003C RID: 60
    public static readonly int OFN_HIDEREADONLY = 4;

    // Token: 0x0400003D RID: 61
    public static readonly int OFN_LONGNAMES = 2097152;

    // Token: 0x0400003E RID: 62
    public static readonly int OFN_NOCHANGEDIR = 8;

    // Token: 0x0400003F RID: 63
    public static readonly int OFN_NODEREFERENCELINKS = 1048576;

    // Token: 0x04000040 RID: 64
    public static readonly int OFN_NOLONGNAMES = 262144;

    // Token: 0x04000041 RID: 65
    public static readonly int OFN_NONETWORKBUTTON = 131072;

    // Token: 0x04000042 RID: 66
    public static readonly int OFN_NOREADONLYRETURN = 32768;

    // Token: 0x04000043 RID: 67
    public static readonly int OFN_NOTESTFILECREATE = 65536;

    // Token: 0x04000044 RID: 68
    public static readonly int OFN_NOVALIDATE = 256;

    // Token: 0x04000045 RID: 69
    public static readonly int OFN_OVERWRITEPROMPT = 2;

    // Token: 0x04000046 RID: 70
    public static readonly int OFN_PATHMUSTEXIST = 2048;

    // Token: 0x04000047 RID: 71
    public static readonly int OFN_READONLY = 1;

    // Token: 0x04000048 RID: 72
    public static readonly int OFN_SHAREAWARE = 16384;

    // Token: 0x04000049 RID: 73
    public static readonly int OFN_SHOWHELP = 16;
    // Token: 0x06000042 RID: 66 RVA: 0x000029E0 File Offset: 0x00000BE0
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

    // Token: 0x06000044 RID: 68 RVA: 0x00002B30 File Offset: 0x00000D30
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

    // Token: 0x06000045 RID: 69 RVA: 0x00002B60 File Offset: 0x00000D60
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
