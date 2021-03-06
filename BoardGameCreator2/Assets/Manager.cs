﻿using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviourPunCallbacks, IHandOver
{
    public Camera main_camera;//=視点カメラ
    [SerializeField] private GameObject player_prfab;
    public List<string> datas;
    public GameObject HandContent;
    public GameObject HandButton;
    private Transform Content_transform;
    public GameObject panel;//=手札のパネル
    public static string ExeURL;
    public Text roomID;
    private void Awake()
    {
#if UNITY_EDITOR
        ExeURL = @"C:\Users\holme\Desktop\もいっこ用";
#else
        ExeURL = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
#endif
        Content_transform = HandContent.transform;
        Debug.Log(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));
    }
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        //PhotonNetwork.ConnectUsingSettings();
        if (Load.ROOM_NAME == "")
        {
            Load.ROOM_NAME = "room";
        }
        PhotonNetwork.JoinOrCreateRoom(Load.ROOM_NAME, new RoomOptions(), TypedLobby.Default);
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    //public override void OnConnectedToMaster()
    //{
    //    // room_nameの値の名前のルームに参加する（ルームが無ければ作成してから参加する）
    //    if(Load.ROOM_NAME == null)
    //    {
    //        Load.ROOM_NAME = "room";
    //    }
    //    PhotonNetwork.JoinOrCreateRoom(Load.ROOM_NAME, new RoomOptions(), TypedLobby.Default);
    //}

    // マッチングが成功した時に呼ばれるコールバック

    public override void OnJoinedRoom()
    {
        //GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(0, 0, 0), Quaternion.identity);
#if UNITY_EDITOR
        datas = ControlJson.LoadJson(@"C:\Users\holme\Desktop\もいっこ用\TableGameData\" + Load.FOLDER_NAME);
#else
        datas = ControlJson.LoadJson(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),"TableGameData",Load.FOLDER_NAME));
#endif
        foreach (string item in datas)
        {
            Debug.Log(item);
        }
        GameObject obj_player = PhotonNetwork.Instantiate("player_ graphic", main_camera.transform.position, Quaternion.identity);
        main_camera.transform.parent = obj_player.transform;
        obj_player.AddComponent<CameraController>();
        roomID.text = "RoomID:" + Load.ROOM_NAME;
    }

    //ルームから退出する
    public void Leaveroom()
    {
        PhotonNetwork.LeaveRoom(false);
        SceneManager.LoadScene("Load");
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
            int count = 0;
            float pos_rate = 1.4f;

            foreach (string data in datas)
            {
                Data temp_data = new Data();
                JsonUtility.FromJsonOverwrite(data, temp_data);
                for (int i = 0; i < temp_data.num; i++)
                {
                    if (temp_data.type == "piece")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(pos_rate * count %10, 0, pos_rate * (count / 10)), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL();
                    }
                    else if (temp_data.type == "card")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("Card_prefab", new Vector3(pos_rate * count % 10, 0, pos_rate * (count / 10)), Quaternion.Euler(90, 0, 0));
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL();
                        obj.GetComponent<Card>().SetManager_handover("GameManager");
                        //obj.GetComponent<Card>().SetHand();
                    }
                    else if (temp_data.type == "board")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("BoardMover_prafab", new Vector3(0,0,0), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL();
                    }
                    else if (temp_data.type == "deck")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("Deck_prefab", new Vector3(pos_rate * count % 10, 0, pos_rate * (count / 10)), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL();
                        obj.GetComponent<Deck>().SetHand();
                    }
                    else
                    {
                        Debug.LogError("No object type defined\n=>" + temp_data.type);
                    }

                    count++;
                }
            }
        }
    }

    public void AddHand(GameObject gameObject)
    {
        GameObject obj = Instantiate(HandButton) as GameObject;
        obj.transform.parent = Content_transform;
        obj.GetComponent<HandCard>().setCard(gameObject,player_prfab.GetComponent<Hand>());
        obj.GetComponent<HandCard>().setPanel(panel);
    }
}

