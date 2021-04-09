using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Tile 
{
    string type;
    int x;
    int y;


    public Tile(string type,int x, int y)
    {
        this.x = x;
        this.y = y;
        this.type = type;

    }
    public Vector2Int getCords()
    {
        return new Vector2Int(x, y);
    }
    public void changeType(string type)
    {
        this.type = type;
        return;
    }
    public string getTypeString()
    {
        return type;
    }
}
