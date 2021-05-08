using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Responsible for control on all Menus, which menu is open when.
/// </summary>
public class MenuManager : MonoBehaviour
{
    bool insideGame = false;
    public MenuSwitcherType m_startMenu;
    Menu m_activeMenu;
    Menu[] m_menuArray;
    private void Awake()
    {
        m_menuArray = GetComponentsInChildren<Menu>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneController sceneControler = FindObjectOfType<SceneController>();
        if(sceneControler == null)
        {
            Debug.LogError("no scene controller");
        }
        if (sceneControler.isMainMenu())
        {
            switchMenu(MenuSwitcherType.OUTGAME_MAIN_MENU);
        }
        else
        {
            deactivateMenus();
        }
        
    }
    public void deactivateMenus()
    {
        foreach (Menu mnu in m_menuArray)
        {        
            mnu.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }
    public void activateInGameMenu()
    {
        switchMenu(MenuSwitcherType.INGAME_MAIN_MENU);
        Time.timeScale = 0;
        
    }
    /// <summary>
    /// NONE FOR NO MENU
    /// </summary>
    /// <param name="type"></param>
    public void switchMenu(MenuSwitcherType type)
    {
        setInsideGameStatus(type);
        if (type == MenuSwitcherType.MAIN_MENU)
        {
            if (insideGame)
            {
                type = MenuSwitcherType.INGAME_MAIN_MENU;
            }
            else
            {
                type = MenuSwitcherType.OUTGAME_MAIN_MENU;
            }
        }
        setActiveMenues(type);
        if (type == MenuSwitcherType.NONE || type == MenuSwitcherType.NEW_GAME)
        {
            m_activeMenu = null;
            Time.timeScale = 1;
            SceneController sceneCtrl = FindObjectOfType<SceneController>();
            insideGame = true;
            if(type == MenuSwitcherType.NEW_GAME)
            {
                SaveData.current.clearSaveFile();
                sceneCtrl.LoadStartingScene();
            }
                
        }
    }

    private void setInsideGameStatus(MenuSwitcherType type)
    {
        if (m_activeMenu == null)
        {
            if (type == MenuSwitcherType.INGAME_MAIN_MENU)
            {
                insideGame = true;
            }
            else if (type == MenuSwitcherType.OUTGAME_MAIN_MENU)
            {
                insideGame = false;
            }
        }
    }

    private void setActiveMenues(MenuSwitcherType type)
    {
        foreach (Menu mnu in m_menuArray)
        {
            if (mnu.m_menuType == type)
            {


                mnu.gameObject.SetActive(true);
                m_activeMenu = mnu;

            }
            else
            {
                mnu.gameObject.SetActive(false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
