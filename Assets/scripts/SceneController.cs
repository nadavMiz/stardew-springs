using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




/// <summary>
/// controlls ALL scene changes ;
/// </summary>
public class SceneController : MonoBehaviour
{

    public bool isMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return true;
        return false;
    }
    public void SceneControllerAction(SceneControllerActionType type)
    {
        switch(type)
        {
            case (SceneControllerActionType.NONE):
                Debug.LogError("UnAssigned Button SceneControllerAction");

                break;

            default:
                Debug.LogError("SceneControllerAction unimplemented switch case");
                break;
        }
    }

    public void LoadStartingScene()
    {
        SceneManager.LoadScene(1);
    }

    public void switchScene(SceneControllerActionType type)
    {
        switch (type)
        {
            case (SceneControllerActionType.START_FIRST_SCENE):

                LoadStartingScene();
                break;

            default:
                Debug.LogError("unrecognized  SceneControllerActionType ");
                break;
        }


    }
}


public enum SceneControllerActionType
{
    NONE,
    START_FIRST_SCENE
}