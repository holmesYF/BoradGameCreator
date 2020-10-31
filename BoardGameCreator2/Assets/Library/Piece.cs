﻿using System;
using Photon.Pun;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Piece : IObject
{ 
    //private PhotonView my_photonView;  親クラスに実装
    private FileControl f_controler;
    private bool saface = true;
    public bool havedflag = false;

    public override void Awake()
    {
        base.Awake();
        this.f_controler = base.gameObject.GetComponent<FileControl>();
    }

    private void Start()
    {
        this.f_controler.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
    }

    public override void RightClick()
    {
        Debug.Log("Piece click by right");
        my_photonView.RPC("ChangeObjectTextuer", RpcTarget.All, Array.Empty<object>());
    }

    public override void LeftClick()
    {

    }


    public override void PopUpInfo()
    {
        Debug.Log("popup piece");
    }



    [PunRPC]
    public void ChangeObjectTextuer()
    {
        bool flag = this.saface;
        if (flag)
        {
            Debug.Log("change to image2");
            this.f_controler.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL2);
            this.saface = false;
        }
        else
        {
            Debug.Log("change to image1");
            this.f_controler.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
            this.saface = true;
        }
    }

}
