using System;
using UnityEngine;
using Photon.Pun;

// Token: 0x02000007 RID: 7
public class Card : IObject
{
    public Texture texture;
    private FileControl f_controller;
    private bool saface = true;
    public IHandOver manager_handover;


    public override void MouseScrollWheel(bool direction)
    {
        if (direction)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
    }

    public override void Awake()
    {
        base.Awake();
        this.f_controller = base.gameObject.GetComponent<FileControl>();
        this.type = "card";
    }
    private void Start()
    {
        this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
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
            this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
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
        manager_handover.AddHand(this.gameObject);
    }
    public void SetManager_handover()
    {
        my_photonView.RPC("_SetManager_handover", RpcTarget.All);
    }

    [PunRPC]
    private void _SetManager_handover()
    {
        manager_handover =  GameObject.Find("GameManager").GetComponent<Manager>();
    }
}
