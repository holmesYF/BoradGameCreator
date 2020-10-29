using System;
using Photon.Pun;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Hand : MonoBehaviour
{
    // Token: 0x04000012 RID: 18
    private GameObject clickedGameObject;

    // Token: 0x04000013 RID: 19
    private GameObject havedObject;

    // Token: 0x04000014 RID: 20
    private Transform HaveObjectPos;

    // Token: 0x04000015 RID: 21
    private PhotonView photonview;

    // Token: 0x04000016 RID: 22
    private Vector3 pos;
    // Token: 0x06000034 RID: 52 RVA: 0x00002594 File Offset: 0x00000794
    private void Update()
    {

        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            bool flag = this.havedObject == null;
            if (flag)
            {
                this.clickedGameObject = null;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = default(RaycastHit);
                bool flag2 = Physics.Raycast(ray, out hit);
                if (flag2)
                {
                    this.clickedGameObject = hit.collider.gameObject;
                }
                bool flag3 = this.clickedGameObject != null;
                if (flag3)
                {
                    bool flag4 = this.clickedGameObject.tag == "moveable" || this.clickedGameObject.tag == "coin";
                    if (flag4)
                    {
                        bool isMine = this.clickedGameObject.GetComponent<PhotonView>().IsMine;
                        if (isMine)
                        {
                            this.havedObject = this.clickedGameObject;
                            this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                            this.photonview = this.havedObject.GetComponent<PhotonView>();
                        }
                        else
                        {
                            this.clickedGameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                            this.havedObject = this.clickedGameObject;
                            this.HaveObjectPos = this.havedObject.GetComponent<Transform>();
                            this.photonview = this.havedObject.GetComponent<PhotonView>();
                        }
                    }
                }
            }
            else
            {
                this.havedObject = null;
                this.HaveObjectPos = null;
                this.photonview = null;
            }
        }
        bool flag5 = this.havedObject != null;
        if (flag5)
        {
            this.pos = Camera.main.WorldToScreenPoint(this.HaveObjectPos.transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.pos.z);
            Vector3 b = Camera.main.ScreenToWorldPoint(a);
            this.HaveObjectPos.position = new Vector3(b.x, 0.1f, b.z);
            Debug.Log(this.HaveObjectPos.transform);
        }
        if (Input.GetMouseButtonDown(1) && this.havedObject != null)
        {
            IObject obj = GetIObject(havedObject);
            bool flag10 = obj != null;
            if (flag10)
            {
                obj.RightClick();
            }
        }
        else
        {
            bool flag11 = this.havedObject == null;
            if (flag11)
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2 = default(RaycastHit);
                bool flag12 = Physics.Raycast(ray2, out hit2);
                if (flag12)
                {
                    this.clickedGameObject = hit2.collider.gameObject;
                }
                bool flag13 = this.clickedGameObject != null;
                if (flag13)
                {
                    bool flag14 = this.clickedGameObject.tag == "moveable" || this.clickedGameObject.tag == "coin";
                    if (flag14)
                    {
                        IObject obj2 = GetIObject(havedObject);
                        bool flag18 = obj2 != null;
                        if (flag18)
                        {
                            obj2.PopUpInfo();
                        }
                    }
                }
            }
        }

        if(havedObject != null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                IObject iobj = GetIObject(havedObject);
                iobj.MouseScrollWheel(true);
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                IObject iobj = GetIObject(havedObject);
                iobj.MouseScrollWheel(false);
            }
        }
    }


    private IObject GetIObject(GameObject obj)
    {
        IObject iobj = null;
        //bool flag7 = this.havedObject.GetComponent<Piece>() != null;
        if (this.havedObject.GetComponent<Piece>() != null)
        {
            iobj = this.havedObject.GetComponent<Piece>();
        }
        //bool flag8 = this.havedObject.GetComponent<Card>() != null;
        else if (this.havedObject.GetComponent<Card>() != null)
        {
            iobj = this.havedObject.GetComponent<Card>();
        }
        //bool flag9 = this.havedObject.GetComponent<Deck>() != null;
        else if (this.havedObject.GetComponent<Deck>() != null)
        {
            iobj = this.havedObject.GetComponent<Deck>();
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
