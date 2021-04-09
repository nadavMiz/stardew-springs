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

    public bool Save()
    {
        Debug.Log("saveData was saved");
        SerializationManager.Save("game3",this);
        return true;
    }
    public bool Load()
    {

        _current = SerializationManager.Load("game3");
        return true;
    }

    internal void setGrowthTable(float[,] v)
    {
        m_savedGrowthTable = v;
    }
}
