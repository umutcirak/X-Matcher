using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI grid_input;
    [SerializeField] TextMeshProUGUI scoreValue;

    GridManager gridManager;
    ScoreKeeper scoreKeeper;

    private float displayScore;
    [SerializeField] float scoreCatchSpeed = 10f;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        grid_input.text = gridManager.gridSize.ToString();
    }

    void Update()
    {
        DisplayScore();
    }

    public void RestartGame()
    {
        string gridText = grid_input.text.ToString();
        int newSize = System.Convert.ToInt32(gridText);   
                
        gridManager.gridSize = newSize;

        scoreKeeper.currentScore = 0;
        SceneManager.LoadScene(1);
    }

    public void OpenMainMenu()
    {
        scoreKeeper.currentScore = 0;
        gridManager.gridSize = 5;
          
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(2);
    }
    public void IncrementGridSize()
    {        
        if(gridManager.gridSize < 25)
        {
            gridManager.gridSize++;
            grid_input.text = gridManager.gridSize.ToString();
        }       
    }
    public void DecreaseGridSize()
    {
        if(gridManager.gridSize > 2)
        {
            gridManager.gridSize--;
            grid_input.text = gridManager.gridSize.ToString();
        }        
    }


    void DisplayScore()
    {
        if (displayScore - scoreKeeper.currentScore < 0.05f)
        {
            displayScore = Mathf.Lerp(displayScore, scoreKeeper.currentScore, scoreCatchSpeed * Time.deltaTime);
        }
        else
        {
            displayScore = scoreKeeper.currentScore;
        }

        scoreValue.text = displayScore.ToString("0");
    }



}
