using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deleteMe : MonoBehaviour
{
    public Text text;
    counter m_counter ;
    GamePersistentData m_gamePersistentData;
    public FarmController[] m_farmControllersArray = new FarmController[1];

    void Start()
    {
        m_gamePersistentData = FindObjectOfType<GamePersistentData>();

        
    }
    // should save the farm on click
    public void up()
    {
        m_gamePersistentData.SaveGame();

        //m_gamePersistentData.SaveGame(m_counter);
    }
    public void down()
    {
        m_counter.current--;
        text.text = m_counter.current.ToString();
        //m_gamePersistentData.SaveGame(m_counter);
    }
}

[System.Serializable]
public class counter
{
    public int current = 0;



}

