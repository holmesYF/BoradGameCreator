using System;
using UnityEngine;
using Photon.Pun;

// Token: 0x02000007 RID: 7
public class Card : IObject
{
    public Texture texture;
    private FileControl f_controller;
    private bool saface = true;


    public override void Awake()
    {
        base.Awake();
        this.f_controller = base.gameObject.GetComponent<FileControl>();
    }
    private void Start()
    {
        this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
    }
    private void Update()
    {
    }

    public override void RightClick()
    {
        Debug.Log("Card click by right");
        my_photonView.RPC("ChangeObjectTextuer", RpcTarget.All, Array.Empty<object>());
    }

    public override void LeftClick()
    {
    }

    public GameObject GetObject()
    {
        return base.gameObject;
    }


    public GameObject GetRefObject()
    {
        return base.gameObject;
    }


    public override void PopUpInfo()
    {
    }

    [PunRPC]
    public void ChangeObjectTextuer()
    {
        bool flag = this.saface;
        if (flag)
        {
            Debug.Log("change to image2");
            GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
            this.saface = false;
        }
        else
        {
            Debug.Log("change to image1");
            this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
            this.saface = true;
        }
    }
}
