using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject text_field;
    private Text text;
    public static string loadURL;
    public static string room_name;
    private void Awake()
    {
        text = text_field.GetComponent<Text>();
    }
    public void OnClickLoadRoom()
    {
        loadURL =  OpenFileName.ShowDialog();
    }

    public void Load_room()
    {
        Load.room_name = text.text;
        SceneManager.LoadScene("Game");
    }


}
