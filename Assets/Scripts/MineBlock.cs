using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    private float longTouchTime = 0.5f;
    private float touchTime = 0f;

    private bool touchEventReady = true;

    public void Click()
    {
        Debug.Log("Click");
    }

    public void LongTouch()
    {
        Debug.Log("LongTouch");
    }

    //private void OnMouseUp()
    //{
    //    touchEventReady = true;
    //}

    //private void OnMouseDown()
    //{
    //    touchEventReady = false;
    //}

    private void OnMouseUpAsButton()
    {
        Click();
    }

    // 클릭 중 계속해서 동작
    private void OnMouseDrag()
    {
        touchTime += Time.deltaTime;
        if(touchTime >= longTouchTime)
        {
            LongTouch();
        }
    }

}
