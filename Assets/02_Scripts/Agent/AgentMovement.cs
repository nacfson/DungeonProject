using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;
public class AgentMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    public UnityEvent<Vector2> OnMousePosChanged;
    public Vector2 GetFloatMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 xy = new Vector2(x,y);
        return xy;
    }
    public void Move()
    {
        transform.Translate(GetFloatMove().normalized * Time.fixedDeltaTime * moveSpeed);
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
        Move();
    }
}
