using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    public void Click()
    {
        Debug.Log("Click");
    }

    public void LongTouch()
    {
        Debug.Log("LongTouch");
    }

    private void OnMouseUpAsButton()
    {
        Click();
    }

}
