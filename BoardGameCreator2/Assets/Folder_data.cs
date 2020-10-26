using System;

// Token: 0x0200000A RID: 10
public static class Folder_data
{
    // Token: 0x06000030 RID: 48 RVA: 0x00002551 File Offset: 0x00000751
    public static void setGamename(string name)
    {
        Folder_data.game_name = name;
    }

    // Token: 0x06000031 RID: 49 RVA: 0x0000255A File Offset: 0x0000075A
    public static void setFolderURL(string url)
    {
        Folder_data.folder_URL = url;
    }

    // Token: 0x06000032 RID: 50 RVA: 0x00002564 File Offset: 0x00000764
    public static string getGamename()
    {
        return Folder_data.game_name;
    }

    // Token: 0x06000033 RID: 51 RVA: 0x0000257C File Offset: 0x0000077C
    public static string getFolderURL()
    {
        return Folder_data.folder_URL;
    }

    // Token: 0x04000010 RID: 16
    private static string folder_URL;

    // Token: 0x04000011 RID: 17
    private static string game_name;
}
