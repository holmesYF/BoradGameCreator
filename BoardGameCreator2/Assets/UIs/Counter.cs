using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] InputField inputfield; 
    // Start is called before the first frame update
    void Start()
    {
        inputfield.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountUp()
    {
        float count = getValue();
        count += 1;
        inputfield.text = count.ToString();
    }


    public void CountDown()
    {
        float count = getValue();
        count -= 1;
        inputfield.text = count.ToString();
    }

    public float getValue()
    {
        try
        {
            float value = float.Parse(inputfield.text);
            Debug.Log("try");
            return value;
        }
        catch
        {
            inputfield.text = "0";
            return 0.0f;
        }
    }

    public void checkValue()
    {
        try
        {
            float value = float.Parse(inputfield.text);
            Debug.Log("try");
        }
        catch
        {
            inputfield.text = "0";
        }
    }
}
