using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstalledFarmObject : MonoBehaviour
{
    public Farm myFarm = null;
    public Vector2Int? cords = null;
    // Start is called before the first frame update

    public void setFarmObject(Farm farm, Vector2Int cords)
    {
        this.myFarm = farm;
        this.cords = cords;
    }
}
