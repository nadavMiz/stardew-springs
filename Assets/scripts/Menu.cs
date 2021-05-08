using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Menu : MonoBehaviour
{
    [SerializeField] public MenuSwitcherType m_menuType;
    // Start is called before the first frame update
    void Start()
    {
        MenuSwitcherButton [] switchButtonArray = GetComponentsInChildren<MenuSwitcherButton>();
        foreach (MenuSwitcherButton btn in switchButtonArray)
        {
            if(btn.GetComponent<Button>() == null)
            {
                Debug.LogError("MenuSwitcherButton has no button attached");
                return;
            }
            btn.GetComponent<Button>().onClick.AddListener(btn.menuSwitcherClicked);
           

        }
        
    }
    void OnEnable()
    {
        if(m_menuType == MenuSwitcherType.LOAD_GAME || m_menuType == MenuSwitcherType.SAVE_GAME)
        {
            SaveDataButton[] buttonArray = GetComponentsInChildren<SaveDataButton>();
            foreach (SaveDataButton  savebutton in buttonArray)
            {
                savebutton.refreshName();
            }
        }
    }
    void menuSwitcherClicked()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum MenuSwitcherType
{
    NONE,
    MAIN_MENU,
    OUTGAME_MAIN_MENU,
    INGAME_MAIN_MENU,
    LOAD_GAME,
    SAVE_GAME,
    NEW_GAME

}

