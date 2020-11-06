using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    public GameObject LoadManager;
    public void load()
    {
        LoadManager.GetComponent<Load>().Load_room();
    }
}
