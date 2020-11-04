using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHandButton : MonoBehaviour
{
    public GameObject handUI;
    private void Awake()
    {

    }
    public void OnClicked()
    {
        handUI.SetActive(!handUI.activeSelf);
    }
}
