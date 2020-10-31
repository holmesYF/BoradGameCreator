using System;
using Photon.Pun;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Hand : MonoBehaviour
{
    private GameObject rayhitobject;
    private GameObject havedObject;
    private Transform HaveObjectPos;
    private IObject iobj;
    private PhotonView photonview;

    private Vector3 pos;

    private void Update()
    {
        #region オブジェクト所持時フレーム処理用
        if (havedObject != null)
        {
            //オブジェクトの位置をマウスに追従
            this.pos = Camera.main.WorldToScreenPoint(this.HaveObjectPos.transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.pos.z);
            Vector3 b = Camera.main.ScreenToWorldPoint(a);
            this.HaveObjectPos.position = new Vector3(b.x, 0.1f, b.z);
            Debug.Log(this.HaveObjectPos.transform);

            //左クリック
            if (Input.GetMouseButtonDown(0))
            {
                iobj.ChangeHavedFlag(false);
                this.havedObject = null;
                this.HaveObjectPos = null;
                this.photonview = null;
            }
            //右クリック
            else if (Input.GetMouseButtonDown(1) && this.havedObject != null)
            {
                IObject obj = GetIObject(havedObject);
                bool flag10 = obj != null;
                if (flag10)
                {
                    obj.RightClick();
                }
            }
            //マウスホイール回転
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                IObject iobj = GetIObject(havedObject);
                iobj.MouseScrollWheel(true);
            }
            //マウスホイール回転
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                IObject iobj = GetIObject(havedObject);
                iobj.MouseScrollWheel(false);
            }
        }
        #endregion

        #region オブジェクト未所持時フレーム処理用
        else
        {
            this.rayhitobject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = default(RaycastHit);
            if (Physics.Raycast(ray, out hit))
            {
                this.rayhitobject = hit.collider.gameObject;
            }
            if (this.rayhitobject != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (this.rayhitobject.tag == "moveable" || this.rayhitobject.tag == "coin")
                    {
                        iobj = GetIObject(rayhitobject);
                        if (!iobj.havedFlag){
                            iobj.ChangeHavedFlag(true);
                            if (this.rayhitobject.GetComponent<PhotonView>().IsMine)
                            {
                                this.havedObject = this.rayhitobject;
                                this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                                this.photonview = this.havedObject.GetComponent<PhotonView>();
                            }
                            else
                            {
                                this.rayhitobject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                                this.havedObject = this.rayhitobject;
                                this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                                this.photonview = this.havedObject.GetComponent<PhotonView>();
                            }
                        }
                    }
                }
                else
                {
                    IObject obj2 = GetIObject(rayhitobject);
                    if (obj2 != null)
                    {
                        obj2.PopUpInfo();
                    }
                }
            }
        }
        #endregion
        #region 仕様変更前
        //    bool mouseButtonDown = Input.GetMouseButtonDown(0);
        //    if (mouseButtonDown)
        //    {
        //        bool flag = this.havedObject == null;
        //        if (flag)
        //        {
        //            this.clickedGameObject = null;
        //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            RaycastHit hit = default(RaycastHit);
        //            bool flag2 = Physics.Raycast(ray, out hit);
        //            if (flag2)
        //            {
        //                this.clickedGameObject = hit.collider.gameObject;
        //            }
        //            bool flag3 = this.clickedGameObject != null;
        //            if (flag3)
        //            {
        //                bool flag4 = this.clickedGameObject.tag == "moveable" || this.clickedGameObject.tag == "coin";
        //                if (flag4)
        //                {
        //                    bool isMine = this.clickedGameObject.GetComponent<PhotonView>().IsMine;
        //                    if (isMine)
        //                    {
        //                        this.havedObject = this.clickedGameObject;
        //                        this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
        //                        this.photonview = this.havedObject.GetComponent<PhotonView>();
        //                    }
        //                    else
        //                    {
        //                        this.clickedGameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        //                        this.havedObject = this.clickedGameObject;
        //                        this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
        //                        this.photonview = this.havedObject.GetComponent<PhotonView>();
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            this.havedObject = null;
        //            this.HaveObjectPos = null;
        //            this.photonview = null;
        //        }
        //    }
        //    bool flag5 = this.havedObject != null;
        //    if (flag5)
        //    {
        //        this.pos = Camera.main.WorldToScreenPoint(this.HaveObjectPos.transform.position);
        //        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.pos.z);
        //        Vector3 b = Camera.main.ScreenToWorldPoint(a);
        //        this.HaveObjectPos.position = new Vector3(b.x, 0.1f, b.z);
        //        Debug.Log(this.HaveObjectPos.transform);
        //    }
        //    if (Input.GetMouseButtonDown(1) && this.havedObject != null)
        //    {
        //        IObject obj = GetIObject(havedObject);
        //        bool flag10 = obj != null;
        //        if (flag10)
        //        {
        //            obj.RightClick();
        //        }
        //    }
        //    else
        //    {
        //        bool flag11 = this.havedObject == null;
        //        if (flag11)
        //        {
        //            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            RaycastHit hit2 = default(RaycastHit);
        //            bool flag12 = Physics.Raycast(ray2, out hit2);
        //            if (flag12)
        //            {
        //                this.clickedGameObject = hit2.collider.gameObject;
        //            }
        //            bool flag13 = this.clickedGameObject != null;
        //            if (flag13)

        //            else if (this.clickedGameObject.tag == "moveable" || this.clickedGameObject.tag == "coin")
        //            {
        //                IObject obj2 = GetIObject(havedObject);
        //                bool flag18 = obj2 != null;
        //                if (flag18)
        //                {
        //                    obj2.PopUpInfo();
        //                }
        //            }

        //        }
        //    }

        //    if(havedObject != null)
        //    {
        //        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //        {
        //            IObject iobj = GetIObject(havedObject);
        //            iobj.MouseScrollWheel(true);
        //        }
        //        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        //        {
        //            IObject iobj = GetIObject(havedObject);
        //            iobj.MouseScrollWheel(false);
        //        }
        //    }
        //}
        #endregion
    }
    private IObject GetIObject(GameObject obj)
    {
        IObject iobj = null;
        if (obj.GetComponent<Piece>() != null)
        {
            iobj = obj.GetComponent<Piece>();
        }
        //bool flag8 = this.havedObject.GetComponent<Card>() != null;
        else if (obj.GetComponent<Card>() != null)
        {
            iobj = obj.GetComponent<Card>();
        }
        //bool flag9 = this.havedObject.GetComponent<Deck>() != null;
        else if (obj.GetComponent<Deck>() != null)
        {
            iobj = obj.GetComponent<Deck>();
        }
        else if(obj.GetComponent<Board>() != null)
        {
            iobj = obj.GetComponent<Board>();
        }
        else
        {
            Debug.Log("Nothing IOobject");
        }
        return iobj;
    }

    // Token: 0x06000035 RID: 53 RVA: 0x00002439 File Offset: 0x00000639
    public void test()
    {
    }

    // Token: 0x06000036 RID: 54 RVA: 0x000029A6 File Offset: 0x00000BA6
    public void Start()
    {
        this.test();
    }
}
