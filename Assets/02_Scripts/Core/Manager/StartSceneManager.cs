using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : SceneManagerParent
{
    public OptionSceneManager OptionSceneManager
    {
        get 
        { 
            _optionSceneManager ??= GameObject.Find("OptionSceneManager").GetComponent<OptionSceneManager>();
            return _optionSceneManager;
        }
    }
    private OptionSceneManager _optionSceneManager;
    private void Awake() 
    {
        LoadSceneAdditive("OptionScene");
    }

    public void OnOption()
    {
        OptionSceneManager.OnBackButton();
    }
    
}
