using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour, IIteractable
{
    public void interact()
    {
        EventManager.TriggerEvent(TimeEvent.END_OF_DAY);
    }
}
