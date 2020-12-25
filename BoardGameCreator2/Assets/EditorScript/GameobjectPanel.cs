using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameobjectPanel : MonoBehaviour
{
    private EditManager editManager;
    [SerializeField] private Text ObjectName;
    [SerializeField] private Text ImageName1;
    [SerializeField] private Text ImageName2;

    public void EditButton()
    {
        editManager.EditButton(this.gameObject.GetComponent<Data>(), this.gameObject.GetComponent<ImageName>(), this.gameObject);
    }

    public void SetManager(EditManager editManager)
    {
        this.editManager = editManager;
    }

    public void SetName(Data data)
    {
        ObjectName.text = data.type;
        ImageName1.text = ControlString.CutTextBefore(data.imageURL1,'.');
        if (data.imageURL2 != null)
        {
            ImageName2.text = ControlString.CutTextBefore(data.imageURL2,'.');
        }
    }
}
