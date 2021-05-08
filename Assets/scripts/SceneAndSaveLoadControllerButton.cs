using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneAndSaveLoadControllerButton : MonoBehaviour
{
    public SceneControllerActionType m_type = SceneControllerActionType.NONE;

    void Start()
    {
        Button btn = GetComponent<Button>();
        SceneController sceneController = FindObjectOfType<SceneController>();
        if (btn == null)
        {
            Debug.LogError("SceneControllerButton of type " + m_type.ToString() + " no button null");
            return;
        }
        else if (sceneController == null)
        {
            Debug.LogError("SceneControllerButton of type " + m_type.ToString() + " sceneController null");
            return;
        }
        btn.onClick.AddListener(() => { sceneController.SceneControllerAction(m_type);}); 
    }
}
