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
    private GameObject[,] mineBlocks;

    void Start()
    {
        mineBlocks = new GameObject[boardHeightLength, boardWidthLength];
        SpawnMineBlock();
    }

    void SpawnMineBlock()
    {
        // ó������ MineBlock�� ���� �� ��ġ
        Vector2 firstPos = new Vector2(-2.2f, 3.2f);
        float blockSizeX = mineBlockPrefabs.transform.localScale.x;
        float blockSizeY = mineBlockPrefabs.transform.localScale.y;

        for (int i = 0; i < boardHeightLength; ++i)
        {
            for (int j = 0; j < boardWidthLength; ++j)
            {
                mineBlocks[i, j] = Instantiate(mineBlockPrefabs);
                mineBlocks[i, j].transform.position
                    = new Vector2(firstPos.x + blockSizeX * j, firstPos.y - blockSizeY * i);
            }
        }
    }
}
