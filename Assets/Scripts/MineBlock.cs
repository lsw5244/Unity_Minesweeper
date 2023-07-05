using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    [SerializeField]
    private Sprite[] blockNumberIcons;
    [SerializeField]
    private Sprite defaultMineBlockIcon;
    [SerializeField]
    private Sprite flagIcon;

    private float longTouchTime = 0.5f;
    private float touchTime = 0f;

    private bool nowTouch = false;

    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public bool isMine = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Click()
    {
        Debug.Log("Click");
        TouchEnd();
    }

    public void LongTouch()
    {
        Debug.Log("LongTouch");

        if(spriteRenderer.sprite == flagIcon)
        {
            spriteRenderer.sprite = defaultMineBlockIcon;
        }
        else
        {
            spriteRenderer.sprite = flagIcon;
        }

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
