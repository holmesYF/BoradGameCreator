﻿using System.Collections;
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
        //board.transform.position = new Vector3(data.size / 2  + 0.5f, -1f, data.size / 2 + 0.5f);
        //board.transform.localScale = new Vector3(data.size /transform.localScale.x, 0.5f,data.size / transform.localScale.z);
        
        this.SetBoardSize(data.size);

        board.GetComponent<ViewControl>().LoadImage(this.data.getexeURL() + "\\TableGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1);
    }
    //public override void LeftClick()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override void PopUpInfo()
    {
        
    }

    public override void HavedRightClick()
    {
        throw new System.NotImplementedException();
    }

    public override void NotHavedRightClick()
    {
        throw new System.NotImplementedException();
    }
    public void SetBoardSize(float size)
    {
        board.transform.position = new Vector3(size / 2 + 0.5f, -0.2f , size / 2 + 0.5f);
        board.transform.localScale = new Vector3(size / transform.localScale.x, 0.5f, size / transform.localScale.z);
    }
}
