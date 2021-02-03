using System;
using Photon.Pun;
using UnityEngine;
abstract public class IObject : MonoBehaviour
{
    public bool havedFlag = false;
    protected PhotonView my_photonView;
    protected Data data;
    protected ViewControl f_controller;
    public string type = null;

    virtual public void Awake()
    {
        my_photonView = gameObject.GetComponent<PhotonView>();
        data = gameObject.GetComponent<Data>();
        f_controller = base.gameObject.GetComponent<ViewControl>();
    }
    abstract public void HavedRightClick();
    abstract public void NotHavedRightClick();
    //abstract public void LeftClick();
    abstract public void PopUpInfo();
    virtual public void MouseScrollWheel(bool direction) {
        if (direction)
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }

    }
    public void ChangeHavedFlag(bool flag) {
        my_photonView.RPC("_ChangeHavedFlag", RpcTarget.All, flag);
    }
    [PunRPC]
    protected void _ChangeHavedFlag(bool flag)
    {
        havedFlag = flag;
    }
}
