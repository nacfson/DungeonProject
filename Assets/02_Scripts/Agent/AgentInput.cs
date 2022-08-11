using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;
public class AgentInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    public UnityEvent<Vector2> OnMovementKeyExpress;
    public UnityEvent<Vector2> OnMousePosChanged;
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
        Vector2 mouseInWordPos = Define.MainCam.ScreenToWorldPoint(mousePos);
        OnMousePosChanged?.Invoke(mouseInWordPos);
    }
    private void FixedUpdate()
    {
        GetPointerInput();
        GetFloatMove();
    }
}   
