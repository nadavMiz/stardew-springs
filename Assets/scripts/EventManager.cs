using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/**
 * Event manager class to handle to handle events between different components of the game
 * 
 * Avialable event types:
 *      TimeEvent <see cref="TimeEvent"/> - events related to the passing of time in the day (e.g. end of day, start of noon, etc..)
 *      InventoryEvent <see cref="InventoryEvent"/> - events related to state change of the inventory (e.g inventory changed)
 *
 */
public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    private void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    //-----------------------------public functions-----------------------------------------

    /// <summary>
    /// Add a callback function to be envoked when an event triggered.
    /// </summary>
    /// <param name="_eventName"> Name of the event to subscribe to </param>
    /// <param name="_listener"> Callback function to envoke when the event is triggered </param>
    public static void Subscribe(string _eventName, UnityAction _listener)
    {
        if (instance == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            thisEvent.AddListener(_listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(_listener);
            instance.eventDictionary.Add(_eventName, thisEvent);
        }
    }

    /// <summary>
    /// Remove a callback from being invoked when an event id triggered
    /// </summary>
    /// <param name="_eventName"> name of the event being listened to </param>
    /// <param name="_listener"> callback function to unsubscribe </param>
    public static void Unsubscribe(string _eventName, UnityAction _listener)
    {
        if (instance == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            thisEvent.RemoveListener(_listener);
        }
    }

    /// <summary>
    /// Trigger an event. this will cause all calbacks registered to this event to be envoked 
    /// </summary>
    /// <param name="_eventName"> name of the event to trigger </param>
    public static void TriggerEvent(string _eventName)
    {
        if (instance == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            Debug.Log("Event " + _eventName + " was triggered");
            thisEvent.Invoke();
        }
    }
}