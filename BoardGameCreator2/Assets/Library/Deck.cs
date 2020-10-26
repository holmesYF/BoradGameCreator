using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class Deck : MonoBehaviour, IObject
{
    // Token: 0x06000021 RID: 33 RVA: 0x00002439 File Offset: 0x00000639
    public void RightClick()
    {
    }

    // Token: 0x06000022 RID: 34 RVA: 0x00002439 File Offset: 0x00000639
    public void LeftClick()
    {
    }

    // Token: 0x06000023 RID: 35 RVA: 0x00002439 File Offset: 0x00000639
    public void PopUpInfo()
    {
    }

    // Token: 0x06000024 RID: 36 RVA: 0x0000246C File Offset: 0x0000066C
    private Card RandPopCard()
    {
        int pos = UnityEngine.Random.Range(0, this.card_list.Count);
        Card card = this.card_list[pos];
        this.card_list.RemoveAt(pos);
        return card;
    }

    // Token: 0x06000025 RID: 37 RVA: 0x000024AB File Offset: 0x000006AB
    private void AddCardByGameobject(GameObject obj)
    {
        this.AddCard(obj.GetComponent<Card>());
        Destroy(obj);
    }

    // Token: 0x06000026 RID: 38 RVA: 0x000024C2 File Offset: 0x000006C2
    private void AddCard(Card card)
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

    // Token: 0x0400000F RID: 15
    private List<Card> card_list = new List<Card>();
}
