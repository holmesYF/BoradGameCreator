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
    public Dropdown dropdown;
    private GameObject nowGameObject;
    private FileControl nowGameObjectFileControl;
    [SerializeField] private GameObject BoardCountergameObject;
    private Counter boardcounter;
    
   // private List<FileControl> fileControls = new List<FileControl>();
    private string ImageURL;
    // Start is called before the first frame update
    void Start()
    {
        counter = countergameObject.GetComponent<Counter>();
        boardcounter = BoardCountergameObject.GetComponent<Counter>();
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

    public void getImageURL()
    {
        ImageURL =  OpenFileName.ShowDialog();
        //fileControls.ForEach(fileControl =>
        //{
        //    if (ImageURL != null)
        //    {
        //        fileControl.LoadImage(ImageURL);
        //    }
        //});
        nowGameObjectFileControl.LoadImage(ImageURL);

    }

    public void ChangePrefab()
    {
        IObject nowObjectClass;
        nowGameObject.SetActive(false);
        if (dropdown.value == 0)
        {
            nowGameObject = piece;
            BoardCountergameObject.SetActive(false);
            nowObjectClass = piece.GetComponent<Piece>();
            nowGameObjectFileControl = piece.GetComponent<FileControl>();
        }
        else if (dropdown.value == 1)
        {
            BoardCountergameObject.SetActive(false);
            nowGameObject = card;
            nowObjectClass = piece.GetComponent<Card>();
            nowGameObjectFileControl = card.GetComponent<FileControl>();
        }
        else if (dropdown.value == 2)
        {
            BoardCountergameObject.SetActive(true);
            nowGameObject = board;
            nowObjectClass = piece.GetComponent<Board>();
            nowGameObjectFileControl = board.transform.GetChild(0).gameObject.GetComponent<FileControl>();
        }
        else
        {
            
        }
        
        nowGameObject.SetActive(true);
        nowGameObjectFileControl.LoadImage(ImageURL);
    }

    public void ChangeBoradSize()
    {
        board.GetComponent<Board>().SetBoardSize(boardcounter.getValue());
    }
}
