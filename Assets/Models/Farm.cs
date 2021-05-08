using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Farm 
{
    int height = 6;
    int width = 4;
    public Tile [,] farmMatrix;
    public delegate bool cbTileChangedFunc(Vector2Int cords);
    cbTileChangedFunc refreshTile;



    public Farm(cbTileChangedFunc refreshcb)
    {
        
        refreshTile = refreshcb;
        if (SaveData.current.m_savedFarmSkeleton != null)
        {
            farmMatrix = SaveData.current.m_savedFarmSkeleton.m_farmMatrix;
            Debug.LogError("set the farm from the save.");
            return;
        }
        else
        {
            Debug.Log("SaveData.current.m_savedFarmSkeleton is null");
        }
        farmMatrix = new Tile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                farmMatrix[i, j] = new Tile("Empty", i, j);
            }
        }
    }



    public Farm(int x, int y, cbTileChangedFunc refreshcb)
    {
        width = x;
        height = y;
        refreshTile = refreshcb;
        if (SaveData.current.m_savedFarmSkeleton != null)
        {
            farmMatrix = SaveData.current.m_savedFarmSkeleton.m_farmMatrix;
            Debug.Log("set the farm from the save.");
            return;
        }
        farmMatrix = new Tile[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                farmMatrix[i, j] = new Tile("Empty", i, j);
            }
        }
    }








    /// <summary>
    /// this changes a tile type, and calls a controller cb to destroy old object and create new one.
    /// if i try to do a change to the same type, does nothing.
    /// </summary>
    /// <param name="type"></param>
    public void changeType(Vector2Int? cords, string type)
    {
        if(farmMatrix[cords.Value.x, cords.Value.y].getTypeString() == type)
        {
            return;
        }
        farmMatrix[cords.Value.x, cords.Value.y].changeType(type);
        //should call a cb.
        refreshTile(cords.Value);
        return;  
    }
    /// <summary>
    /// this changes a tile type, and calls a controller cb to destroy old object and create new one.
    /// if i try to do a change to the same type, does nothing.
    /// </summary>
    /// <param name="type"></param>
    public void changeType(Vector2Int cords, string type)
    {
        if (farmMatrix[cords.x, cords.y].getTypeString() == type)
        {
            return;
        }
        farmMatrix[cords.x, cords.y].changeType(type);
        //should call a cb.
        refreshTile(cords);
        return;
    }
    /// <summary>
    /// returns the tile type in cords.
    /// </summary>
    /// <param name="cords"></param>
    /// <returns></returns>
    public string getTileType(Vector2Int cords)
    {
        return farmMatrix[cords.x, cords.y].getTypeString();
    }
    public string getTileType(Vector2Int? cords)
    {
        return farmMatrix[cords.Value.x, cords.Value.y].getTypeString();
    }
    public Vector2Int getSize()
    {
        return new Vector2Int(width, height);
    }
    public void saveGame()
    {

    }
}

[System.Serializable]
public class FarmSkeleton
{
    public Tile[,] m_farmMatrix;
    public FarmSkeleton(Tile[,] farmMatrix)
    {
        m_farmMatrix = farmMatrix;
    }
}