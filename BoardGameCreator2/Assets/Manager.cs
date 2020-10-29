﻿using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviourPunCallbacks
{
    public Camera main_camera;//=視点カメラ
    public List<string> datas;
    public string ExeURL;
    private void Awake()
    {
        ExeURL = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
    }
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // room_nameの値の名前のルームに参加する（ルームが無ければ作成してから参加する）
        if(Load.room_name == null)
        {
            Load.room_name = "room";
        }
        PhotonNetwork.JoinOrCreateRoom(Load.room_name, new RoomOptions(), TypedLobby.Default);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        //GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(0, 0, 0), Quaternion.identity);
        datas = ControlJson.LoadJson(@"./BoardGameData");
        foreach (string item in datas)
        {
            Debug.Log(item);
        }
        GameObject obj_player = PhotonNetwork.Instantiate("player_ graphic",main_camera.transform.position,Quaternion.identity);
        main_camera.transform.parent = obj_player.transform;
        obj_player.AddComponent<CameraController>();
    }

    //インスタンス生成

    //json読み込み
    public void LoadJson()
    {

    }
    public void CreateBoardGameObject()
    {
        if (PhotonNetwork.IsMasterClient)
        {

            foreach(string data in datas)
            {
                Data temp_data = new Data();
                JsonUtility.FromJsonOverwrite(data,temp_data);
                for(int i = 0;i < temp_data.num; i++)
                {
                    if(temp_data.type == "piece")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(UnityEngine.Random.Range(-4, 4), 0, UnityEngine.Random.Range(-4, 4)), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL(ExeURL);
                    }
                    else if(temp_data.type == "card")
                    {
                        Debug.Log("まだできてない");
                    }
                    else
                    {
                        Debug.LogError("No object type defined");
                    }
                }
            }
        }
    }
}

