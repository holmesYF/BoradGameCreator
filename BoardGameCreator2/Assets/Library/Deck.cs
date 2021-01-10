using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Token: 0x02000008 RID: 8
public class Deck : IObject
{
    private List<GameObject> card_list = new List<GameObject>();

    public override void HavedRightClick()
    {

    }

    public override void Awake()
    {
        base.Awake();
        this.type = "deck";
    }


    public override void LeftClick()
    {

    }


    public override void PopUpInfo()
    {

    }


    private GameObject RandPopCard()
    {
        int pos = UnityEngine.Random.Range(0, this.card_list.Count);
        GameObject card = this.card_list[pos];
        this.card_list.RemoveAt(pos);
        return card;
    }

    // Token: 0x06000025 RID: 37 RVA: 0x000024AB File Offset: 0x000006AB
    public void AddCardByGameobject(GameObject obj)
    {
        my_photonView.RPC("_AddCardByGameobject", RpcTarget.All, obj.GetComponent<PhotonView>().ViewID);
        //obj.GetComponent<Card>().HideObject();
    }

    public void Test()
    {

    }
    // Token: 0x06000026 RID: 38 RVA: 0x000024C2 File Offset: 0x000006C2
    private void AddCard(GameObject card)
    {
        this.card_list.Add(card);
    }

    // Token: 0x06000027 RID: 39 RVA: 0x00002439 File Offset: 0x00000639
    private void Start()
    {

    }

    // Token: 0x06000028 RID: 40 RVA: 0x00002439 File Offset: 0x00000639
    private void Update()
    {

    }

    [PunRPC]
    public void _AddCardByGameobject(int viewID)
    {
        GameObject card_object = PhotonView.Find(viewID).gameObject;
        AddCard(card_object);
        card_object.SetActive(false);
    }

    public override void NotHavedRightClick()
    {
        throw new NotImplementedException();
    }

    // Token: 0x0400000F RID: 15
}
