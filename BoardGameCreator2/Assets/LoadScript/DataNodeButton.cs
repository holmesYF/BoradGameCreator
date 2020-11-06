using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataNodeButton : MonoBehaviour
{
    public GameObject parent;
    public GameObject folder_name;

    private void Start()
    {
        parent = transform.parent.gameObject.transform.parent.gameObject;
    }

    public void OnClick()
    {
        Load.FOLDER_NAME =  folder_name.GetComponent<Text>().text;
        parent.GetComponent<Content>().load();
    }
}
