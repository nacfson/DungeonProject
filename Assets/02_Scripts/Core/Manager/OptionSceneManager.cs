using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSceneManager : SceneManagerParent
{
    [SerializeField]
    private GameObject _graphicPanel;

    [SerializeField]
    private GameObject _soundPanel;

    [SerializeField]
    private GameObject _mainPanel;



    private bool _onGraphicPanel;
    private bool _onSoundPanel;

    private bool _onBack;
    public void OnExit()
    {
        Application.Quit();
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        ActiveFalsePanel();
        _mainPanel.SetActive(false);
        _onBack = false;
    }
    private void Update()
    {
        OnEscKey();
    }

    public void OnEscKey()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButton();
        }
    }

    private void ActiveFalsePanel()
    {
        _graphicPanel.SetActive(false);
        _soundPanel.SetActive(false);
        _onGraphicPanel= false;
        _onSoundPanel = false;
    }

    public void OnBackButton()
    {
        if(_onBack)
        {
            _mainPanel.SetActive(false);
            _onBack = false;
            Time.timeScale = 1;
            ActiveFalsePanel();
        }
        else
        {
            _mainPanel.SetActive(true);
            _onBack = true;
            Time.timeScale = 0;
            ActiveFalsePanel();
        }
    }
    public void OnGraphicButton()
    {
        if(_onGraphicPanel)
        {
            _graphicPanel.SetActive(false);
            _onGraphicPanel = false;
            _mainPanel.SetActive(true);
            _onBack = true;
        }
        else
        {
            _graphicPanel.SetActive(true);
            _onGraphicPanel = true;
            _mainPanel.SetActive(false);
            _onBack = false;
        }
    }

    public void OnSoundButton()
    {
        if(_onSoundPanel)
        {
            _soundPanel.SetActive(false);
            _onSoundPanel = false;
            _mainPanel.SetActive(true);
            _onBack = true;
        }
        else
        {
            _soundPanel.SetActive(true);
            _onSoundPanel = true;
            _mainPanel.SetActive(false);
            _onBack = false;
        }
    }

    public void On1920x1080()
    {
        Screen.SetResolution(1920,1080,true);
    }
    public void On1600x900()
    {
        Screen.SetResolution(1600,900,true);
    }
    public void On1366x768()
    {
        Screen.SetResolution(1366,768,true);
    }


}
