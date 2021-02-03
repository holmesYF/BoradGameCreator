using System;
using UnityEngine;
using Photon.Pun;

// Token: 0x02000007 RID: 7
public class Card : IObject
{
    public Texture texture;
    //private ViewControl f_controller;　親に実装
    public bool saface = true;
    public IHandOver manager_handover;
    Hand hand;


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
        //this.f_controller = base.gameObject.GetComponent<ViewControl>();
        this.type = "card";
    }
    private void Start()
    {
        this.f_controller.LoadImage(this.data.getexeURL() + "\\TableGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
    }
    private void Update()
    {
    }

    public override void HavedRightClick()
    {
        Debug.Log("Card click by right");
        my_photonView.RPC("_ChangeObjectTextuer", RpcTarget.All);
    }

    //public override void LeftClick()
    //{
    //}

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
    public void _ChangeObjectTextuer()
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
            this.f_controller.LoadImage(this.data.getexeURL() + "\\TableGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
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
    public void SetManager_handover(string manager_name)
    {
        my_photonView.RPC("_SetManager_handover", RpcTarget.All,manager_name);
    }

    [PunRPC]
    private void _SetManager_handover(string manager_name)
    {
        manager_handover =  GameObject.Find(manager_name).GetComponent<Manager>();
    }

    //public void SetHand()
    //{
    //    my_photonView.RPC("_SetHand", RpcTarget.All);
    //}

    //private void _SetHand()
    //{
    //    hand = GameObject.Find("Player_prefab").GetComponent<Hand>();
    //}


}
