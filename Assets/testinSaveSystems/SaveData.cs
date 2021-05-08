using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class SaveData 
{
    private static SaveData _current;

    public FarmSkeleton m_savedFarmSkeleton= null;
    public float[,] m_savedGrowthTable = null;
    
    //public Farm m_farm = null;
    // public Inventory m_Inventory = null;

    public static SaveData current
    {
        get
        {
            if(_current ==null)
            {
                _current = new SaveData();
            }
            return _current;
        }
    }
    public void setFarmSkeleton(Farm farm)
    {
        if(farm == null)
        {
            Debug.LogError("farm is null");
            return;
        }

        _current.m_savedFarmSkeleton = new FarmSkeleton(farm.farmMatrix);
        Debug.Log("farm was set");
    }
    public void clearSaveFile()
    {
        Debug.Log("clear save file called");
        _current.m_savedFarmSkeleton = null;
    }
    public bool Save()
    {
        Debug.Log("saveData was saved");
        SerializationManager.serializeEntireGameToFile("game3",this);
        return true;
    }
    public bool Load()
    {

        _current = SerializationManager.getSaveDataFromSaveFile("game3");
        return true;
    }
    public void gameSaveButtonPress(bool isSave, gameSave saveName)
    {
        if(isSave)
        {
            Save(saveName);
        }
        else
        {
            Load(saveName);
        }
    }
    public bool Save(gameSave saveName)
    {
        Debug.Log("saveData was saved");
        SerializationManager.serializeEntireGameToFile(saveName.ToString(), this);
        return true;
    }
    public bool Load(gameSave saveName)
    {
        _current = SerializationManager.getSaveDataFromSaveFile(saveName.ToString());
        Debug.Log("saveData was loaded");

        return true;
    }
    internal void setGrowthTable(float[,] v)
    {
        m_savedGrowthTable = v;
    }
}
public enum gameSave
{
    SAVEGAME1,
    SAVEGAME2,
    SAVEGAME3
}