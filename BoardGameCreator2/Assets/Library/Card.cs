using System;
using UnityEngine;
using Photon.Pun;

// Token: 0x02000007 RID: 7
public class Card : IObject
{
    public Texture texture;
    private FileControl f_controller;
    private bool saface = true;
    public IHandOver manager;



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

    public override void HavedRightClick()
    {
        Debug.Log("Card click by right");
        my_photonView.RPC("ChangeObjectTextuer", RpcTarget.All);
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

    public void HideObject()
    {
        my_photonView.RPC("_HideObject",RpcTarget.All);
    }

    public void Appear()
    {
        my_photonView.RPC("_Appear",RpcTarget.All);
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

    [PunRPC]
    public void _HideObject()
    {
        this.gameObject.SetActive(false);
    }

    [PunRPC]
    public void _Appear()
    {
        this.gameObject.SetActive(true);
    }

    public override void NotHavedRightClick()
    {
        HideObject();
        manager.AddHand(this.gameObject);
    }
}
