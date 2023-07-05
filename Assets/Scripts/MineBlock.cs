using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    private float longTouchTime = 0.5f;
    private float touchTime = 0f;

    private bool nowTouch = false;
    
    [HideInInspector]
    public bool isMine = false;

    public void Click()
    {
        Debug.Log("Click");
        TouchEnd();
    }

    public void LongTouch()
    {
        Debug.Log("LongTouch");
        TouchEnd();
    }

    private void OnMouseUp()
    {
        TouchEnd();
    }

    private void OnMouseDown()
    {
        nowTouch = true;
    }

    private void OnMouseUpAsButton()
    {
        if (nowTouch == false)
            return;

        Click();
    }

    private void OnMouseDrag()
    {
        if (nowTouch == false)
            return;

        touchTime += Time.deltaTime;
        if(touchTime >= longTouchTime)
        {
            LongTouch();
        }        
    }

    void TouchEnd()
    {
        nowTouch = false;
        touchTime = 0f;
    }
}
