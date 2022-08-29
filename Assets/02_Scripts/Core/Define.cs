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

            _mainCam ??= GameObject.Find("Main Camera").GetComponent<Camera>();
            
            return _mainCam;
        }
    }

    public static CinemachineVirtualCamera Vcam
    {
        get
        {
            _cmVcam ??= GameObject.Find("CM cam").GetComponent<CinemachineVirtualCamera>();
            return _cmVcam;
        }
    }
    private static Camera _mainCam= null;
    private static CinemachineVirtualCamera _cmVcam = null;

}
