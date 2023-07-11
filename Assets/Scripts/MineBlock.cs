using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBlock : MonoBehaviour, IMineBlockEvent
{
    [SerializeField]
    private Sprite[] blockNumberIcons;
    [SerializeField]
    private Sprite defaultBlockIcon;
    [SerializeField]
    private Sprite flagIcon;
    [SerializeField]
    private Sprite explosionBlockIcon;

    private float longTouchTime = 0.5f;
    private float touchTime = 0f;

    private bool nowTouch = false;

    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public bool isMine = false;
    [HideInInspector]
    public int idxI;
    [HideInInspector]
    public int idxJ;

    private GameManager gameManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Click()
    {
        if(isMine == true)
        {
            spriteRenderer.sprite = explosionBlockIcon;
            return;
        }

        //gameManager.AroundMineCheck(idxI, idxJ);
        spriteRenderer.sprite = blockNumberIcons[gameManager.AroundMineCheck(idxI, idxJ)];

        TouchEnd();
    }

    public void LongTouch()
    {
        if(spriteRenderer.sprite == flagIcon)
        {
            spriteRenderer.sprite = defaultBlockIcon;
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

    //---
    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void SetIndex(int i, int j)
    {
        idxI = i;
        idxJ = j;
    }
}
