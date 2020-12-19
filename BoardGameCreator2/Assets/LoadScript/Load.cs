using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject text_field;
    private InputField text;
    public static string loadURL;
    public static string ROOM_NAME;
    public static string FOLDER_NAME;
    private void Awake()
    {
        text = text_field.GetComponent<InputField>();
    }
    public void OnClickLoadRoom()
    {
        loadURL =  OpenFileName.ShowDialog();
    }

    public void Load_room()
    {
        Load.ROOM_NAME = text.text;
        SceneManager.LoadScene("Game");
    }

    public void Load_edit()
    {
        SceneManager.LoadScene("Editor");
    }


}
