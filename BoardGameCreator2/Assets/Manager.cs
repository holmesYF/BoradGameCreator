using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviourPunCallbacks,IHandOver
{
    public Camera main_camera;//=視点カメラ
    public List<string> datas;
    public GameObject HandContent;
    public GameObject HandButton;
    private Transform Content_transform;
    public GameObject panel;//=手札のパネル
    public string ExeURL;
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
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // room_nameの値の名前のルームに参加する（ルームが無ければ作成してから参加する）
        if(Load.ROOM_NAME == null)
        {
            Load.ROOM_NAME = "room";
        }
        PhotonNetwork.JoinOrCreateRoom(Load.ROOM_NAME, new RoomOptions(), TypedLobby.Default);
    }

    // マッチングが成功した時に呼ばれるコールバック

    public override void OnJoinedRoom()
    {
        //GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(0, 0, 0), Quaternion.identity);
#if UNITY_EDITOR
        datas = ControlJson.LoadJson(@"C:\Users\holme\Desktop\もいっこ用\BoardGameData\" + Load.FOLDER_NAME );
#else
        datas = ControlJson.LoadJson(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),"BoardGameData",Load.FOLDER_NAME));
#endif
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
                        GameObject obj = PhotonNetwork.Instantiate("Piece_prefab", new Vector3(UnityEngine.Random.Range(0, 8), 0, UnityEngine.Random.Range(0, 8)), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL(ExeURL);
                    }
                    else if(temp_data.type == "card")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("Card_prefab", new Vector3(UnityEngine.Random.Range(0, 8), 0, UnityEngine.Random.Range(0, 8)), Quaternion.Euler(90, 0, 0));
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL(ExeURL);
                        obj.GetComponent<Card>().manager_handover = this;
                    }
                    else if(temp_data.type == "board")
                    {
                        GameObject obj = PhotonNetwork.Instantiate("BoardMover_prafab", new Vector3(0, -0.5f, 0), Quaternion.identity);
                        obj.GetComponent<Data>().cloneData(data);
                        obj.GetComponent<Data>().setexeURL(ExeURL);
                    }
                    else
                    {
                        Debug.LogError("No object type defined\n=>" + temp_data.type) ;
                    }
                }
            }
        }
    }

    public void AddHand(GameObject gameObject)
    {
        GameObject obj = Instantiate(HandButton) as GameObject;
        obj.transform.parent = Content_transform;
        obj.GetComponent<HandCard>().setCard(gameObject);
        obj.GetComponent<HandCard>().setPanel(panel);
    }
}

