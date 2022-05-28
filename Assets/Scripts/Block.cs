using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{            
    
    public Vector2Int posIndex;
    Vector2 touchPosition;
    
    [Header("Animation")]
    [SerializeField] float rotationSpeed = 15f;
    [SerializeField] float effectTime = 2f;


    Board board;
    MatchFinder matchFinder;

    public List<Block> neighbourBlocks;
    public bool isVisible = false;
    public bool isMatched = false;    

    void Awake()
    {
        board = FindObjectOfType<Board>();
        matchFinder = FindObjectOfType<MatchFinder>();
    }

    void Start()
    {
        List<Block> neighbourBlocks = new List<Block>();        
    }
    
    void Update()
    {
       
    }


    void OnMouseDown()
    {
        if(isVisible || isMatched || board.currentTransition == Board.BoardTransition.processing) { return; }                  
                
        SetVisible(true);        
        matchFinder.visibleBlocks.Add(this);
        matchFinder.FindVisibleNeighbors();
        matchFinder.FillMatches();             
        
    }

    public void SetVisible(bool value)
    {
        SpriteRenderer spRndr = GetComponent<SpriteRenderer>();
        spRndr.enabled = value;
        isVisible = value;
    }


    public void ResetBlock()
    {                    
        neighbourBlocks.Clear();
        StartCoroutine(BlockAnimationCo());

        
    }


    

    IEnumerator BlockAnimationCo()
    {       
        Vector3 scaleVector = new Vector3(0.01f, 0.01f, 0.01f);        

        int counter = 0;
        while(counter < 50)
        {
            counter++;

            transform.Rotate(0f, 10f, 0f);            
            transform.localScale += scaleVector;

            yield return new WaitForSeconds(0.01f);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        isMatched = false;
        SetVisible(false);

        board.currentTransition = Board.BoardTransition.notProcessing;
    }







}
