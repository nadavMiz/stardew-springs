using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGO : MonoBehaviour
{
    public void changeto(string _objName)
    {
        Farm farm = GetComponent<InstalledFarmObject>().myFarm;
        Vector2Int? myvec = GetComponent<InstalledFarmObject>().cords;
        farm.changeType(myvec, _objName);
    }

}
