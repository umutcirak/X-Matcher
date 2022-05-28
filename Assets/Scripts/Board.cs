using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board Settings")]
    public int gridSize;
    [SerializeField] GameObject bgTilePrefab;


    [Header("Block Settings")]
    [SerializeField] Block blockPrefab;


    public enum BoardTransition{ processing, notProcessing };
    public BoardTransition currentTransition = BoardTransition.notProcessing;
    public Block[,] allBlocks;


    MatchFinder matchFinder;
    AudioManager audioManager;
    GridManager gridManager;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        matchFinder = FindObjectOfType<MatchFinder>();
        audioManager = FindObjectOfType<AudioManager>();
        gridManager = FindObjectOfType<GridManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    void Start()
    {
        gridSize = gridManager.gridSize;
        allBlocks = new Block[gridSize, gridSize];        
        FillBgTile();
    }

    
    void Update()
    {
        VeilMatchedBlocks();
    }


    void FillBgTile()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector2 pos = new Vector2(x, y);

                GameObject bgTile = Instantiate(bgTilePrefab, pos, Quaternion.identity);
                bgTile.transform.parent = transform;
                bgTile.name = "BG Tile-" + x + "," + y;

                SpawnBlock(x, y);
               
            }

        }
    }
    

    void SpawnBlock(int xPos, int yPos)
    {
        Vector2 pos = new Vector2(xPos, yPos);
        Block blockToUse = Instantiate(blockPrefab, pos, Quaternion.identity);
        blockToUse.transform.parent = transform;
        blockToUse.name = "Block: " + xPos + "," + yPos;
        blockToUse.posIndex = new Vector2Int(xPos, yPos);
        blockToUse.SetVisible(false);

        allBlocks[xPos, yPos] = blockToUse;      
            
    }

    public void VeilMatchedBlocks()
    {
        if (matchFinder.currentMatches.Count < 3) { return; }

        currentTransition = BoardTransition.processing;        
        audioManager.PlayMatchClip();

        int matchSize = matchFinder.currentMatches.Count;
        scoreKeeper.IncrementScore(matchSize);
        Debug.Log(matchSize);

        for (int i = 0; i < matchFinder.currentMatches.Count; i++)
        {
            int x = matchFinder.currentMatches[i].posIndex.x;
            int y = matchFinder.currentMatches[i].posIndex.y;

            allBlocks[x, y].ResetBlock();
        }

        matchFinder.currentMatches.Clear();
       

    }

    












}
