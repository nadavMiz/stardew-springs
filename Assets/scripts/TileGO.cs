using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGO : MonoBehaviour
{
    [SerializeField] private bool m_isTilled;

    public void changeto(string _objName)
    {
        Farm farm = GetComponent<InstalledFarmObject>().myFarm;
        Vector2Int? myvec = GetComponent<InstalledFarmObject>().cords;
        farm.changeType(myvec, _objName);
    }

    public bool isTilled() 
    {
        return m_isTilled;
    }

}
