using System;
using Photon.Pun;
using UnityEngine;
abstract public class IObject : MonoBehaviour
{ 
    public bool havedFlag = false;
    protected PhotonView my_photonView;
    protected Data data;

    virtual public void Awake()
    {
        my_photonView = gameObject.GetComponent<PhotonView>();
        data = gameObject.GetComponent<Data>();
    }
    abstract public void RightClick();

    abstract public void LeftClick();
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
    virtual public void ChangeHavedFlag(bool flag) {
        my_photonView.RPC("_ChangeHavedFlag", RpcTarget.All, flag);
    }
    [PunRPC]
    virtual protected void _ChangeHavedFlag(bool flag)
    {
        havedFlag = flag;
    }


}
