using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditManager : MonoBehaviour
{
    [SerializeField] private GameObject countergameObject;
    private Counter counter;
    public GameObject piece;//=piece_prefab
    public GameObject card;//=card_prefab;
    public GameObject board;//=boardmover_prefab;
    public Dropdown Type_dropdown;
    private GameObject nowGameObject;
    private FileControl nowGameObjectFileControl;
    [SerializeField] private GameObject BoardCountergameObject;
    private Counter boardSizeCounter;
    //private GameObject ScrollView;
    [SerializeField] private GameObject ScrollViewContent;
    [SerializeField] private GameObject ContentPanel_prefab;
    // private List<FileControl> fileControls = new List<FileControl>();
    private string ImageURL1;
    private string ImageURL2;
    [SerializeField] private GameObject ImageURL2_Button;
    // Start is called before the first frame update
    void Start()
    {
        counter = countergameObject.GetComponent<Counter>();
        boardSizeCounter = BoardCountergameObject.GetComponent<Counter>();
        BoardCountergameObject.SetActive(false);
        Debug.Log(piece);
        piece.SetActive(true);
        //fileControls.Add(piece.GetComponent<FileControl>());
        //fileControls.Add(card.GetComponent<FileControl>());
        //fileControls.Add(board.transform.GetChild(0).gameObject.GetComponent<FileControl>());
        nowGameObject = piece;
        nowGameObjectFileControl = piece.GetComponent<FileControl>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getImageURL1()
    {
        ImageURL1 = OpenFileName.ShowDialog();
        nowGameObjectFileControl.LoadImage(ImageURL1);
    }
    public void getImageURL2()
    {
        ImageURL2 = OpenFileName.ShowDialog();
        nowGameObjectFileControl.LoadImage(ImageURL2);
    }

    public void ChangePrefab()
    {
        IObject nowObjectClass;
        nowGameObject.SetActive(false);
        if (Type_dropdown.value == 0)
        {
            nowGameObject = piece;
            BoardCountergameObject.SetActive(false);
            ImageURL2_Button.SetActive(true);
            nowObjectClass = piece.GetComponent<Piece>();
            nowGameObjectFileControl = piece.GetComponent<FileControl>();
        }
        else if (Type_dropdown.value == 1)
        {
            BoardCountergameObject.SetActive(false);
            ImageURL2_Button.SetActive(false);
            nowGameObject = card;
            nowObjectClass = piece.GetComponent<Card>();
            nowGameObjectFileControl = card.GetComponent<FileControl>();
        }
        else if (Type_dropdown.value == 2)
        {
            BoardCountergameObject.SetActive(true);
            ImageURL2_Button.SetActive(false);
            nowGameObject = board;
            nowObjectClass = piece.GetComponent<Board>();
            nowGameObjectFileControl = board.transform.GetChild(0).gameObject.GetComponent<FileControl>();
        }
        else
        {

        }

        nowGameObject.SetActive(true);
        nowGameObjectFileControl.LoadImage(ImageURL1);
    }

    public void ChangeBoradSize()
    {
        board.GetComponent<Board>().SetBoardSize(boardSizeCounter.getValue());
        board.GetComponent<Transform>().position = new Vector3(-18.0f - boardSizeCounter.getValue(), -2.92f, -15 + boardSizeCounter.getValue() / 2);
    }

    public void DoneButton()
    {
        GameObject obj = Instantiate(ContentPanel_prefab) as GameObject;
        obj.transform.parent = ScrollViewContent.transform;
        Data data = obj.AddComponent<Data>();
        data.type = Type_dropdown.captionText.text;
        data.num = (int)counter.getValue();
        data.imageURL1 = ControlString.CutText(ImageURL1, '\\');
        if (data.type == "piece")
        {
            data.imageURL2 = ControlString.CutText(ImageURL2, '\\');
        }
        if (data.type == "board")
        {
            data.size = (int)boardSizeCounter.getValue();
        }
    }

    public void ExportButton()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < ScrollViewContent.transform.childCount; i++)
        {
            Debug.Log(JsonUtility.ToJson(ScrollViewContent.transform.GetChild(i).gameObject.GetComponent<Data>()));
            list.Add(JsonUtility.ToJson(ScrollViewContent.transform.GetChild(i).gameObject.GetComponent<Data>()));
        }
#if UNITY_EDITOR
        ControlJson.ListOutPutJson(list, @"C:\Users\holme\Desktop\もいっこ用\BoradGameData");
#else
        ControlJson.ListOutPutJson(list,AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));
#endif
        Debug.Log(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));
    }
}
