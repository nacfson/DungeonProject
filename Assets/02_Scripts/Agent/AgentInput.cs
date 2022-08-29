using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;
using Cinemachine;

public class AgentInput : MonoBehaviour
{
    public Camera MainCam
    {
        get
        {

            _mainCam ??= GameObject.Find("Main Camera").GetComponent<Camera>();
            
            return _mainCam;
        }
    }

    public CinemachineVirtualCamera Vcam
    {
        get
        {
            _cmVcam ??= GameObject.Find("CM cam").GetComponent<CinemachineVirtualCamera>();
            return _cmVcam;
        }
    }
    private Camera _mainCam= null;
    private CinemachineVirtualCamera _cmVcam = null;
    [SerializeField] private float moveSpeed = 3f;
    public UnityEvent<Vector2> OnMovementKeyExpress;
    public UnityEvent<Vector2> OnMousePosChanged;
    public UnityEvent OnFireButtonPress;

    public UnityEvent OnFireButtonRelease;

    private bool _fireButtonDown = false;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        _fireButtonDown = false;
    }
    public void GetFloatMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        OnMovementKeyExpress?.Invoke(new Vector2(x,y));
    }

    public void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector2 mouseInWordPos = MainCam.ScreenToWorldPoint(mousePos);
        OnMousePosChanged?.Invoke(mouseInWordPos);
    }

    private void GetFireInput()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(_fireButtonDown == false)
            {
                _fireButtonDown = true;
                OnFireButtonPress?.Invoke();
            }
            else
            {
                if(_fireButtonDown == true)
                {
                    _fireButtonDown = false;
                    OnFireButtonRelease?.Invoke();


                }
            }
        }
    }
    private void FixedUpdate()
    {
        GetPointerInput();
        GetFloatMove();
        GetFireInput();
    }
}   
