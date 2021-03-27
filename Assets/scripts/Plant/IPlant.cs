using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlant
{
    /// <summary>
    /// water the plant. increase the current groth by m_growthRate at the end of the day
    /// </summary>
    void Water();

    /// <summary>
    /// pick up plants 
    /// </summary>
    void Pick();
}
