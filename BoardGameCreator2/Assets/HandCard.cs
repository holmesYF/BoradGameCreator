﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class HandCard : MonoBehaviour
{
    private GameObject card_object;
    private Card card_class;
    GameObject parent;
    PhotonView my_PhotonView;
    Texture texture;
    Data data;
    Image image;
    Button button;
    public GameObject panel;
    Hand hand;

    private void Awake()
    {

        image = this.gameObject.GetComponent<Image>();
        button = this.gameObject.GetComponent<Button>();
    }

    public void Start()
    {
        parent = transform.parent.gameObject;
        button.onClick.AddListener(OutPutHand);
        data = card_object.GetComponent<Data>();
        StartCoroutine(SetSprite(this.data.getexeURL() + "\\TableGameData\\" + Load.FOLDER_NAME + "\\" + this.data.imageURL1));
    }

    public IEnumerator SetSprite(String url)
    {
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("ここは->" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));

            Debug.LogError(www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image.sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), Vector2.zero);
        }
    }

    public void setCard(GameObject card_object, Hand hand)
    {
        this.card_object = card_object;
        this.card_class = card_object.GetComponent<Card>();
        this.hand = hand;
    }

    public void setPanel(GameObject panel)
    {
        this.panel = panel;
    }

    public void OutPutHand()
    {

        card_class.Appear();
        hand.SetHandGameobject(this.card_object);
        //card_class.ChangeHavedFlag(true);
        panel.SetActive(false);
        Destroy(this.gameObject);

    }
}
