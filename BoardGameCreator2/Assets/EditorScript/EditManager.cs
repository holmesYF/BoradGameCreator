using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject PieceSurfaceChangeButton;//=PieceSurfaceChangeButton
    [SerializeField] private GameObject gamenameObject;//=Gamename
    private InputField gamename;
    [SerializeField] private GameObject ImageURL2_Button;
    private bool piece_surface = true;



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
        gamename = gamenameObject.GetComponent<InputField>();
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
            PieceSurfaceChangeButton.SetActive(true);
            nowObjectClass = piece.GetComponent<Piece>();
            nowGameObjectFileControl = piece.GetComponent<FileControl>();
        }
        else if (Type_dropdown.value == 1)
        {
            BoardCountergameObject.SetActive(false);
            ImageURL2_Button.SetActive(false);
            PieceSurfaceChangeButton.SetActive(false);
            nowGameObject = card;
            nowObjectClass = piece.GetComponent<Card>();
            nowGameObjectFileControl = card.GetComponent<FileControl>();
        }
        else if (Type_dropdown.value == 2)
        {
            BoardCountergameObject.SetActive(true);
            ImageURL2_Button.SetActive(false);
            PieceSurfaceChangeButton.SetActive(false);
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
        data.imageURL1 = ControlString.CutTextAfter(ImageURL1, '\\');
        obj.GetComponent<ImageName>().ImageURL1 = ImageURL1;
        if (data.type == "piece")
        {
            data.imageURL2 = ControlString.CutTextAfter(ImageURL2, '\\');
            obj.GetComponent<ImageName>().ImageURL2 = ImageURL2;
        }
        if (data.type == "board")
        {
            data.size = (int)boardSizeCounter.getValue();
        }
        obj.GetComponent<GameobjectPanel>().SetManager(this);
        obj.GetComponent<GameobjectPanel>().SetName(data);
    }

    public void ExportButton()
    {
        String path;
        String gamenamestring = gamename.text;
#if UNITY_EDITOR
        path = @"C:\Users\holme\Desktop\もいっこ用\BoradGameData\" + gamenamestring;
#else
        path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\BoardGameData\" + gamenamestring;
#endif
        if (!Directory.Exists(path))
        {
            List<string> list = new List<string>();
            Directory.CreateDirectory(path);
            for (int i = 0; i < ScrollViewContent.transform.childCount; i++)
            {
                Debug.Log(JsonUtility.ToJson(ScrollViewContent.transform.GetChild(i).gameObject.GetComponent<Data>()));
                GameObject ContentChild;
                ContentChild = ScrollViewContent.transform.GetChild(i).gameObject;
                ContentChild.GetComponent<ImageName>().MoveImage(path);
                list.Add(JsonUtility.ToJson(ContentChild.GetComponent<Data>()));
            }
            ControlJson.ListOutPutJson(list, path);
        }
        else
        {
            return;
        }
        Debug.Log(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));
        SceneManager.LoadScene("Load");
    }

    public void ChangePieceSurfaceButton()
    {
        if (piece_surface)
        {

        }
        else
        {

        }
    }

    public void EditButton(Data data, ImageName imageName, GameObject gameObject)
    {
        ImageURL1 = imageName.ImageURL1;
        ImageURL2 = imageName.ImageURL2;
        counter.setValue(data.num);
        boardSizeCounter.setValue(data.size);
        switch (data.type)
        {
            case "piece":
                Type_dropdown.value = 0;
                break;
            case "card":
                Type_dropdown.value = 1;
                break;
            case "board":
                Type_dropdown.value = 2;
                break;

        }
        Destroy(gameObject);
    }

    public void testButton()
    {
        File.Copy(@"C:\Users\holme\Desktop\ビルド\BoardGameData\オセロ\gleen.png", @"C:\Users\holme\Desktop\test\b.png");
        Debug.Log("Test");

    }
}
