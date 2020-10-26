using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviourPunCallbacks
{
    public GameObject card;
    public GameObject piece;
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
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
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
            foreach (string data in datas)
            {
                GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(UnityEngine.Random.Range(-4, 4), 0, UnityEngine.Random.Range(-4, 4)), Quaternion.identity);
                obj.GetComponent<Data>().cloneData(data);
                obj.GetComponent<Data>().setexeURL(ExeURL);
            }
        }
    }
}

