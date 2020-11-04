using System;
using UnityEngine;
using Photon.Pun;

[Serializable]
public class Data : MonoBehaviour
{
    public string type;
    public string fig_type;
    public string imageURL1;
    public string imageURL2;
    public int num;
    public int size;

    private string exeURL;
    private PhotonView my_photonView;

    //public void setData(string type, string imageURL1)
    //{
    //    this.type = type;
    //    this.imageURL1 = imageURL1;
    //    this.imageURL2 = null;
    //    this.num = 1;
    //}
    //public void setData(string type, string imageURL1, int num)
    //{
    //    this.type = type;
    //    this.imageURL1 = imageURL1;
    //    this.imageURL2 = null;
    //    this.num = num;
    //}
    //public void setData(string type, string imageURL1, string imageURL2)
    //{
    //    this.type = type;
    //    this.imageURL1 = imageURL1;
    //    this.imageURL2 = imageURL2;
    //    this.num = 1;
    //}
    //public void setData(string type, string imageURL1, string imageURL2, int num)
    //{
    //    this.type = type;
    //    this.imageURL1 = imageURL1;
    //    this.imageURL2 = imageURL2;
    //    this.num = num;
    //}

    public void Awake()
    {
        my_photonView = this.gameObject.GetComponent<PhotonView>();
    }

    public void cloneData(string data)
    {
        my_photonView.RPC("_cloneData", RpcTarget.All, data);
    }
    public void setexeURL(string url)
    {
        my_photonView.RPC("_setexeURL", RpcTarget.All, url);
    }

    public string getexeURL()
    {
        return exeURL;
    }
    [PunRPC]
    public void _cloneData(string data)
    {
        JsonUtility.FromJsonOverwrite(data, this);
    }
    [PunRPC]
    public void _setexeURL(string url)
    {
        this.exeURL = url;
    }
}