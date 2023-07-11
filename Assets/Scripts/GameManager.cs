using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mineBlockPrefabs;

    private int boardWidthLength = 12;
    private int boardHeightLength = 20;
    private int mineCount = 56;
    private MineBlock[,] mineBlocks;

    void Start()
    {
        mineBlocks = new MineBlock[boardHeightLength, boardWidthLength];
        SpawnMineBlock();
        MinePlant();
    }

    void SpawnMineBlock()
    {
        // 처음으로 MineBlock이 생성 될 위치
        Vector2 firstPos = new Vector2(-2.2f, 3.2f);
        float blockSizeX = mineBlockPrefabs.transform.localScale.x;
        float blockSizeY = mineBlockPrefabs.transform.localScale.y;

        for (int i = 0; i < boardHeightLength; ++i)
        {
            for (int j = 0; j < boardWidthLength; ++j)
            {
                mineBlocks[i, j] = Instantiate(mineBlockPrefabs).GetComponent<MineBlock>();
                mineBlocks[i, j].transform.position
                    = new Vector2(firstPos.x + blockSizeX * j, firstPos.y - blockSizeY * i);
                mineBlocks[i, j].SetGameManager(this);
                mineBlocks[i, j].SetIndex(i, j);
            }
        }
    }

    void MinePlant()
    {
        for(int i = 0; i < mineCount; ++i)
        {
            int x = Random.Range(0, boardWidthLength);
            int y = Random.Range(0, boardHeightLength);

            if(mineBlocks[y, x].isMine == false)
            {
                mineBlocks[y, x].isMine = true;
            }
            else
            {
                --i;
            }

        }
    }

    public int AroundMineBlockCheck(int i, int j)
    {
        int aroundMineCount = 0;

        int checkIdxI;
        int checkIdxJ;

        // TopLeft
        checkIdxI = i - 1;
        checkIdxJ = j - 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // Top
        checkIdxI = i - 1;
        checkIdxJ = j;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // TopRight
        checkIdxI = i - 1;
        checkIdxJ = j + 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // Left
        checkIdxI = i;
        checkIdxJ = j - 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // Right
        checkIdxI = i;
        checkIdxJ = j + 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // BottomLeft
        checkIdxI = i + 1;
        checkIdxJ = j - 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // Bottom
        checkIdxI = i + 1;
        checkIdxJ = j;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);

        // BottomRight
        checkIdxI = i + 1;
        checkIdxJ = j + 1;
        CheckMineBlock(checkIdxI, checkIdxJ, ref aroundMineCount);


        return aroundMineCount;
    }

    void CheckMineBlock(int i, int j, ref int aroundMineCount)
    {
        if (i < 0 || i >= boardHeightLength)
        {
            return;
        }

        if (j < 0 || j >= boardWidthLength)
        {
            return;
        }

        if (mineBlocks[i, j].isMine == true)
        {
            aroundMineCount++;
        }
    }
}
