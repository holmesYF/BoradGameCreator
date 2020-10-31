using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Board : IObject
{
    GameObject board;
    public override void Awake()
    {
        base.Awake();
        board = gameObject.transform.Find("Board").gameObject;
    }
    private void Start()
    {
        board.transform.position = new Vector3(data.size / 2  + 0.5f, -1f, data.size / 2 + 0.5f);
        board.transform.localScale = new Vector3(data.size / transform.localScale.x, 0.5f,data.size / transform.localScale.z);
        board.GetComponent<FileControl>().LoadImage(this.data.getexeURL() + "\\BoardGameData\\" + this.data.imageURL1);
    }
    public override void LeftClick()
    {
        throw new System.NotImplementedException();
    }

    public override void PopUpInfo()
    {
        
    }

    public override void RightClick()
    {
        throw new System.NotImplementedException();
    }
}
