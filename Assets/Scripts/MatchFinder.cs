using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchFinder : MonoBehaviour
{

    public List<Block> visibleBlocks;
    public List<Block> currentMatches;

    Board board;


    void Awake()
    {
        board = FindObjectOfType<Board>();
    }

    void Start()
    {
        currentMatches = new List<Block>();
        visibleBlocks = new List<Block>();
    }   
   

    public void FindVisibleNeighbors()
    {        

        for (int x = 0; x < board.gridSize; x++)
        {
            for (int y = 0; y < board.gridSize; y++)
            {
                Block currentBlock = board.allBlocks[x, y];

                if (currentBlock != null)
                {
                    currentBlock.neighbourBlocks.Clear();
                    if (currentBlock.isVisible)
                    {
                        // Left 
                        if (x > 0)
                        {
                            Block leftBlock = board.allBlocks[x - 1, y];

                            if (leftBlock != null && leftBlock.isVisible)
                            {
                                currentBlock.neighbourBlocks.Add(leftBlock);
                            }
                        }
                        // Right 
                        if (x < board.gridSize - 1)
                        {
                            Block rightBlock = board.allBlocks[x + 1, y];

                            if (rightBlock != null && rightBlock.isVisible)
                            {
                                currentBlock.neighbourBlocks.Add(rightBlock);
                            }
                        }

                        // Below 
                        if (y > 0)
                        {
                            Block belowBlock = board.allBlocks[x, y - 1];

                            if (belowBlock != null && belowBlock.isVisible)
                            {
                                currentBlock.neighbourBlocks.Add(belowBlock);
                            }
                        }
                        // Above 
                        if (y < board.gridSize - 1)
                        {
                            Block upperBlock = board.allBlocks[x, y + 1];

                            if (upperBlock != null && upperBlock.isVisible)
                            {
                                currentBlock.neighbourBlocks.Add(upperBlock);
                            }
                        }

                    }


                }

            }

        }



    }


    public void FindMatches()
    {       

        for (int x = 0; x < board.gridSize; x++)
        {
            for (int y = 0; y < board.gridSize; y++)
            {
                Block currentBlock = board.allBlocks[x, y];

                if(currentBlock != null)
                {
                    if(currentBlock.neighbourBlocks.Count >= 2)
                    {
                        currentBlock.isMatched = true;                        
                    }

                    if (currentBlock.isMatched)
                    {          
                        foreach (Block neighborBlock in currentBlock.neighbourBlocks)
                        {                           
                            neighborBlock.isMatched = true;
                        }
                    }


                }

            }
        }
        

    }


    public void FillMatches()
    {
        currentMatches.Clear();
        FindMatches();

        for (int x = 0; x < board.gridSize; x++)
        {
            for (int y = 0; y < board.gridSize; y++)
            {
                if(board.allBlocks[x,y] != null)
                {
                    if (board.allBlocks[x, y].isMatched)
                    {
                        currentMatches.Add(board.allBlocks[x, y]);
                    }
                }             
                
            }
        }

        currentMatches = currentMatches.Distinct().ToList();
    }




}
