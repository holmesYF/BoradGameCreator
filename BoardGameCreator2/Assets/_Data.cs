using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data
{
    public string type;
    public string imageURL1;
    public string imageURL2;
    public int num;
    public void setData(string type, string imageURL1)
    {
        this.type = type;
        this.imageURL1 = imageURL1;
        this.imageURL2 = null;
        this.num = 1;
    }
    public void setData(string type, string imageURL1, int num)
    {
        this.type = type;
        this.imageURL1 = imageURL1;
        this.imageURL2 = null;
        this.num = num;
    }
    public void setData(string type, string imageURL1, string imageURL2)
    {
        this.type = type;
        this.imageURL1 = imageURL1;
        this.imageURL2 = imageURL2;
        this.num = 1;
    }
    public void setData(string type, string imageURL1, string imageURL2, int num)
    {
        this.type = type;
        this.imageURL1 = imageURL1;
        this.imageURL2 = imageURL2;
        this.num = num;
    }
}
