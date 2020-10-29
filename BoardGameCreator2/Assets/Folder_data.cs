using System;

// Token: 0x0200000A RID: 10
public static class Folder_data
{
    private static string folder_URL;
    private static string game_name;
    private static string room_name;
    public static void setGamename(string name)
    {
        Folder_data.game_name = name;
    }
    public static void setFolderURL(string url)
    {
        Folder_data.folder_URL = url;
    }
    public static string getGamename()
    {
        return Folder_data.game_name;
    }
    public static string getFolderURL()
    {
        return Folder_data.folder_URL;
    }
    public static void setRoomName(string room_name)
    {
        Folder_data.room_name = room_name;
    }

}
