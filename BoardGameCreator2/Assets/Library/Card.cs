using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class Card : MonoBehaviour, IObject
{
    // Token: 0x06000019 RID: 25 RVA: 0x00002439 File Offset: 0x00000639
    private void Start()
    {
    }

    // Token: 0x0600001A RID: 26 RVA: 0x00002439 File Offset: 0x00000639
    private void Update()
    {
    }

    // Token: 0x0600001B RID: 27 RVA: 0x00002439 File Offset: 0x00000639
    public void RightClick()
    {
    }

    // Token: 0x0600001C RID: 28 RVA: 0x00002439 File Offset: 0x00000639
    public void LeftClick()
    {
    }

    // Token: 0x0600001D RID: 29 RVA: 0x0000243C File Offset: 0x0000063C
    public GameObject GetObject()
    {
        return base.gameObject;
    }

    // Token: 0x0600001E RID: 30 RVA: 0x00002454 File Offset: 0x00000654
    public GameObject GetRefObject()
    {
        return base.gameObject;
    }

    // Token: 0x0600001F RID: 31 RVA: 0x00002439 File Offset: 0x00000639
    public void PopUpInfo()
    {
    }

    public void MouseScrollWheel(bool flag)
    {
        throw new NotImplementedException();
    }
}
