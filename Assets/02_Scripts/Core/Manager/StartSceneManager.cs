using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : SceneManagerParent
{
    private void Awake() 
    {
        LoadSceneAdditive("OptionScene");
    }
    
}
