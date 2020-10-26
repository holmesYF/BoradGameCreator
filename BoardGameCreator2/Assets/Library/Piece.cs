using System;
using Photon.Pun;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Piece : MonoBehaviour, IObject
{
    // Token: 0x0400004A RID: 74
    private PhotonView my_photonView;

    // Token: 0x0400004B RID: 75
    private FileControl f_controler;

    // Token: 0x0400004C RID: 76
    private Data data;

    // Token: 0x0400004D RID: 77
    private string exeURL;

    // Token: 0x0400004E RID: 78
    private bool saface = true;
    // Token: 0x06000047 RID: 71 RVA: 0x00002CC0 File Offset: 0x00000EC0
    public void Awake()
    {
        this.my_photonView = base.gameObject.GetComponent<PhotonView>();
        this.f_controler = base.gameObject.GetComponent<FileControl>();
        this.data = base.gameObject.GetComponent<Data>();
    }

    // Token: 0x06000048 RID: 72 RVA: 0x00002CF6 File Offset: 0x00000EF6
    public void RightClick()
    {
        Debug.Log("Piece click by right");
        this.my_photonView.RPC("ChangeObjectTextuer", RpcTarget.All, Array.Empty<object>());
    }

    // Token: 0x06000049 RID: 73 RVA: 0x00002439 File Offset: 0x00000639
    public void LeftClick()
    {
    }

    // Token: 0x0600004A RID: 74 RVA: 0x00002439 File Offset: 0x00000639
    public void PopUpInfo()
    {
    }

    // Token: 0x0600004B RID: 75 RVA: 0x00002D1C File Offset: 0x00000F1C
    public void testChangeObjectTextuer()
    {
        bool flag = this.saface;
        if (flag)
        {
            Debug.Log("change to image2 ->" + this.data.imageURL2);
            this.f_controler.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL2);
            this.saface = false;
        }
        else
        {
            Debug.Log("change to image1->" + this.data.imageURL1);
            this.f_controler.LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
            this.saface = true;
        }
    }

    // Token: 0x0600004C RID: 76 RVA: 0x00002DD8 File Offset: 0x00000FD8
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
