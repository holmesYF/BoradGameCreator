﻿using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200000B RID: 11
public class Hand : MonoBehaviour
{
    private GameObject rayhitobject;
    [SerializeField]private GameObject havedObject;
    private Transform HaveObjectPos;
    private IObject iobj;
    private PhotonView photonview;

    private Vector3 pos;

    private void Awake()
    {

    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            #region オブジェクト所持時フレーム処理用
            if (havedObject != null)
            {
                //オブジェクトの位置をマウスに追従
                this.pos = Camera.main.WorldToScreenPoint(this.HaveObjectPos.transform.position);
                Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.pos.z);
                Vector3 b = Camera.main.ScreenToWorldPoint(a);
                this.HaveObjectPos.position = new Vector3(b.x, 0f, b.z);
                //Debug.Log(this.HaveObjectPos.transform);

                //左クリック
                if (Input.GetMouseButtonDown(0))
                {
                    iobj.ChangeHavedFlag(false);
                    if (iobj.type == "card")
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

                            if (this.rayhitobject.tag == "moveable" || this.rayhitobject.tag == "coin")
                            {
                                IObject iobj2 = GetIObject(rayhitobject);
                                if (iobj2.type == "deck")
                                {
                                    rayhitobject.GetComponent<Deck>().AddCardByGameobject(havedObject);
                                }
                            }

                        }
                    }
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
                        obj.HavedRightClick();
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
                            SetHandGameobject(this.rayhitobject);
                        }
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        if (this.rayhitobject.tag == "moveable" || this.rayhitobject.tag == "coin")
                        {
                            iobj = GetIObject(rayhitobject);
                            if (!iobj.havedFlag)
                            {
                                //iobj.ChangeHavedFlag(true);
                                if (this.rayhitobject.GetComponent<PhotonView>().IsMine)
                                {
                                    iobj.NotHavedRightClick();
                                }
                                else
                                {
                                    this.rayhitobject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                                    iobj.NotHavedRightClick();
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
    }
    private IObject GetIObject(GameObject obj)
    {
        IObject iobj = null;
        if (obj.GetComponent<Piece>() != null)
        {
            iobj = obj.GetComponent<Piece>();
        }
        else if (obj.GetComponent<Card>() != null)
        {
            iobj = obj.GetComponent<Card>();
        }
        else if (obj.GetComponent<Deck>() != null)
        {
            iobj = obj.GetComponent<Deck>();
        }
        else if (obj.GetComponent<Board>() != null)
        {
            iobj = obj.GetComponent<Board>();
        }

        else
        {
            Debug.Log("Nothing IOobject");
        }
        return iobj;
    }

    public void test()
    {
    }

    public void Start()
    {
        this.test();
    }

    public void SetHandGameobject(GameObject obj)
    {
        iobj = GetIObject(obj);
        if (!iobj.havedFlag)
        {
            iobj.ChangeHavedFlag(true);
            if (obj.GetComponent<PhotonView>().IsMine)
            {
                this.havedObject = obj;
                this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                this.photonview = this.havedObject.GetComponent<PhotonView>();
            }
            else
            {
                obj.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                this.havedObject = obj;
                this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                this.photonview = this.havedObject.GetComponent<PhotonView>();
            }
        }
    }
}
