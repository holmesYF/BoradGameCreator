using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public static string loadURL;
    public void OnClickLoadRoom()
    {
        loadURL =  OpenFileName.ShowDialog();
    }

    public void Load_room()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
