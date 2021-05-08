using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    Farm farm;
    public Vector2Int inGamelocation = new Vector2Int(0, 0);
    Vector2 offset = new Vector2(0.5f,0.5f);
    public PrefabDB farmDB = null;
    GameObject[,] ControllerfarmMatrix;
    GameObject GameObjectContainer;
    Dictionary<string, GameObject> prefabDictionary;
    // Start is called before the first frame update
    void Start()
    {
        farm = new Farm(refreshTile);
        GameObjectContainer = new GameObject();
        Vector2Int sizeVector = farm.getSize();
        ControllerfarmMatrix = new GameObject[sizeVector.x, sizeVector.y];
        initFarmGameObjects();
        loadGrowthValueIfAny();
    }


    public void loadGrowthValueIfAny()
    {
        Vector2Int sizeVector = farm.getSize();
        float[,] growthTable = SaveData.current.m_savedGrowthTable;
        if (growthTable == null)
        {
            return;
        }
        for (int i = 0; i < sizeVector.x; i++)
        {
            for (int j = 0; j < sizeVector.y; j++)
            {
                PlantImp currPlantImp = ControllerfarmMatrix[i, j].GetComponent<PlantImp>();
                if (currPlantImp != null)
                {
                    ControllerfarmMatrix[i, j].GetComponent<PlantImp>().SetupGrowth(growthTable[i, j]);
                }
            }
        }

    }






    public bool refreshTile(int x, int y)
    {
        return refreshTile(new Vector2Int(x, y));
    }
    public bool refreshTile(Vector2Int? vec)
    {
        return refreshTile(vec.Value);
    }
    public bool refreshTile(Vector2Int cords)
    {
        GameObject gameObjectprefab;
        Tile tile = farm.farmMatrix[cords.x, cords.y];
        string typename = tile.getTypeString();
        if (!prefabDictionary.ContainsKey(typename))
        {
            Debug.LogError("can't refresh tile (" +cords.x +", "+ cords.y +") , missing a prefab with name " + typename);
            return false;
        }
        Destroy(ControllerfarmMatrix[cords.x, cords.y]);
        prefabDictionary.TryGetValue(typename, out gameObjectprefab);
        GameObject myGameObject = Instantiate(gameObjectprefab, new Vector3(cords.x + offset.x + inGamelocation.x, cords.y + offset.y + inGamelocation.y), Quaternion.identity);
        myGameObject.transform.parent = GameObjectContainer.transform;
        ControllerfarmMatrix[cords.x, cords.y] = myGameObject;
        InstalledFarmObject farnObject = myGameObject.AddComponent<InstalledFarmObject>();
        myGameObject.GetComponent<InstalledFarmObject>().setFarmObject(farm, cords);
        return true;
    }

    public void initFarmGameObjects()
    {
        prefabDictionary = farmDB.initAndGetDictionary();
        foreach (Tile tile in farm.farmMatrix)
        {
            GameObject gameObjectprefab;
            Vector2Int cords = tile.getCords();
            string typename = tile.getTypeString();
            if(!prefabDictionary.ContainsKey(typename))
            {
                Debug.LogError("can't init farm controller, missing a prefab with name " + typename);
                return;
            }
            prefabDictionary.TryGetValue(typename, out gameObjectprefab);
            GameObject myGameObject = Instantiate(gameObjectprefab, new Vector3(cords.x + offset.x + inGamelocation.x, cords.y + offset.y+ inGamelocation.y), Quaternion.identity);
            myGameObject.transform.parent = GameObjectContainer.transform;
            ControllerfarmMatrix[cords.x, cords.y] = myGameObject;
            InstalledFarmObject farnObject = myGameObject.AddComponent<InstalledFarmObject>();
            myGameObject.GetComponent<InstalledFarmObject>().setFarmObject(farm, cords);
        }
    }
    float [,] CreateGrowthTable()
    {
        Vector2Int sizeVector = farm.getSize();
        float[,] myArray = new float[sizeVector.x, sizeVector.y];

        for (int i = 0; i < sizeVector.x; i++)
        {
            for (int j = 0; j < sizeVector.y; j++)
            {
                PlantImp plant = ControllerfarmMatrix[i,j].GetComponent<PlantImp>();
                if(plant!=null)
                {
                    myArray[i, j] = plant.m_currentGrowth;
                }
                else
                {
                    myArray[i, j] = 0;
                }
            }
            
        }
        return myArray;

    }

    /// <summary>
    /// gets the farm model
    /// </summary>
    public Farm getFarmModel()
    {
        return farm;
    }

    //the growth table is going to be a 2d array with growth value.

    public void saveFarm()
    {
        SaveData.current.setFarmSkeleton(farm);
        SaveData.current.setGrowthTable(CreateGrowthTable());  
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
