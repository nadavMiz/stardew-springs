using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class SaveDataButton : MonoBehaviour
{

    public bool isSave;
    public gameSave gameSave;
    // Start is called before the first frame update
    void Awake()
    {
        Button btn = GetComponent<Button>();
        if (btn == null)
        {
            Debug.LogError("no Button component for saveDataButton");
            return;
        }
        string name = PlayerPrefs.GetString(gameSave.ToString(), gameSave.ToString());
        GetComponentInChildren<TextMeshProUGUI>().SetText(name);
        btn.onClick.AddListener(saveGameButtonPressed);
    }
    public void refreshName()
    {
        string name = PlayerPrefs.GetString(gameSave.ToString(), gameSave.ToString());
        GetComponentInChildren<TextMeshProUGUI>().SetText(name);
    }
    void Start()
    {

    }
    
    public void saveGameButtonPressed()
    {
        SaveData.current.gameSaveButtonPress(isSave, gameSave);
        FarmController farmController = FindObjectOfType<FarmController>();

        if (farmController != null && isSave)
        {
            PlayerPrefs.SetString(gameSave.ToString(), getDateString());
            string name = PlayerPrefs.GetString(gameSave.ToString(), gameSave.ToString());
            GetComponentInChildren<TextMeshProUGUI>().SetText(name);
            farmController.saveFarm();
        }
        else
        {
            SceneController scenectrlr = FindObjectOfType<SceneController>();
            if (scenectrlr == null)
            {
                Debug.LogError("missing scene controller");
            }
            scenectrlr.LoadStartingScene();
        }
        MenuManager menuManager = FindObjectOfType<MenuManager>();
        if(menuManager!=null)
        {
            menuManager.deactivateMenus();
        }
        SaveData.current.gameSaveButtonPress(isSave, gameSave);



    }
    public string getDateString()
    {
        /*
        string saveGame = System.DateTime.Now.Year.ToString() + "," + System.DateTime.Now.Month + ","
    + System.DateTime.Now.Hour.ToString() + "," + System.DateTime.Now.Minute.ToString() + "," + System.DateTime.Now.Second.ToString();
        System.DateTime.Now.Year.ToString();
        //here is the save game
        */
        string saveGame = System.DateTime.Now.ToString("r", DateTimeFormatInfo.InvariantInfo);
        return saveGame;
        //save the game actually
    }
}
