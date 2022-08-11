using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Define
{
    public static Camera MainCam
    {
        get
        {
            if(_mainCam == null)
            {
                _mainCam = Camera.main;
            }
            return _mainCam;
        }
    }

    public static CinemachineVirtualCamera Vcam
    {
        get
        {
            _cmVcam ??= GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            return _cmVcam;
        }
    }
    private static Camera _mainCam= null;
    private static CinemachineVirtualCamera _cmVcam = null;

}
