using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //time speed values
    private const float TIME_INTERVAL = 1.0f;
    private const int TIME_INCREMENT = 10;

    private const int MORNING_START_TIME = 6 * 60; // 6:00

    public TextMeshProUGUI m_clock;

    private static System.Tuple<int, string>[] m_dayParts = {
        System.Tuple.Create(12 * 60, TimeEvent.NOON_START),
        System.Tuple.Create(22 * 60, TimeEvent.EVENING_START),
        System.Tuple.Create(24 * 60, TimeEvent.MIDNIGHT_START),
        System.Tuple.Create(28 * 60, TimeEvent.END_OF_DAY)
    };

    private int m_gameTime = MORNING_START_TIME; //current in game time in minutes
    private float m_lastTime = 0.0f; // last real time that the in game time was incremented in
    private int m_nextDayPartIdx = 0;

    /// <summary>
    /// get the current in game clock hour
    /// </summary>
    /// <returns>current in game hour</returns>
    public int CurrentGameHour() { return m_gameTime / 60 % 24; }

    /// <summary>
    /// get the current in game clock minutes
    /// </summary>
    /// <returns>current in game minutes</returns>
    public int CurrentGameMinute() { return m_gameTime % 60; }

    private void UpdateUI() 
    {
        m_clock.text = string.Format("{0:00}:{1:00}", CurrentGameHour(), CurrentGameMinute());
    }

    private void TriggerEvents()
    {
        while ((m_nextDayPartIdx < m_dayParts.Length) && (m_gameTime >= m_dayParts[m_nextDayPartIdx].Item1))
        {
            Debug.Log("TimeManager::TriggerEvents: time: " + m_gameTime + " is passed: " + m_dayParts[m_nextDayPartIdx].Item1 + " triggering event: " + m_dayParts[m_nextDayPartIdx].Item2);
            
            //workaround - increment time part of day, before triggering the event in case it gets overwriten by the event
            ++m_nextDayPartIdx;
            EventManager.TriggerEvent(m_dayParts[m_nextDayPartIdx - 1].Item2);
        }
    }

    private void EndDay()
    {
        m_gameTime = MORNING_START_TIME;
        m_nextDayPartIdx = 0;
        UpdateUI();
    }

    private void Start()
    {
        EventManager.Subscribe(TimeEvent.END_OF_DAY, EndDay);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - m_lastTime) >= TIME_INTERVAL)
        { 
            m_gameTime += TIME_INCREMENT;
            TriggerEvents();
            UpdateUI();
            m_lastTime = Time.time;
        }
    }
}
