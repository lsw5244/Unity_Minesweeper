using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    private float longTouchTime = 0.5f;
    private float touchTime = 0f;

    private bool nowTouch = false;

    public void Click()
    {
        if (nowTouch == false)
            return;

        Debug.Log("Click");
        nowTouch = false;
    }

    public void LongTouch()
    {
        Debug.Log("LongTouch");
        nowTouch = false;
    }

    private void OnMouseUp()
    {
        nowTouch = false;
    }

    private void OnMouseDown()
    {
        nowTouch = true;
    }

    private void OnMouseUpAsButton()
    {
        Click();
    }

    // 클릭 중 계속해서 동작
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
}
