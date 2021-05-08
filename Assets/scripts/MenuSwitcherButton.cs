using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//
public class MenuSwitcherButton : MonoBehaviour
{
    public MenuSwitcherType m_type;
    MenuManager m_menuManager;

    void Awake()
    {
        m_menuManager = GetComponentInParent<MenuManager>();
        if(m_menuManager==null)
        {
            Debug.LogError("no Menu Manager found, loose Menu Switcher Button, very bad indeed failing button init");
            return;
        }
    }
    public void menuSwitcherClicked()
    {
        m_menuManager.switchMenu(m_type);
    }


}
