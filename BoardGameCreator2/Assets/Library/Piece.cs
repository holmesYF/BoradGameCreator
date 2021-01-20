using System;
using Photon.Pun;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Piece : IObject
{ 
    //private PhotonView my_photonView;  親クラスに実装
    private ViewControl f_controller;
    private bool saface = true;

    public override void Awake()
    {
        base.Awake();
        this.f_controller = base.gameObject.GetComponent<ViewControl>();
    }

    private void Start()
    {
        this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
    }

    public override void HavedRightClick()
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
            this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL2);
            this.saface = false;
        }
        else
        {
            Debug.Log("change to image1");
            this.f_controller.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
            this.saface = true;
        }
    }

    public override void NotHavedRightClick()
    {
        throw new NotImplementedException();
    }
}
