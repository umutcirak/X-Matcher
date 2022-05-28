using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
            
    void Start()
    {
        scoreText.text = FindObjectOfType<ScoreKeeper>().currentScore.ToString();
    }    

    public void OpenMainMenu()
    {
        FindObjectOfType<ScoreKeeper>().currentScore = 0;
        FindObjectOfType<GridManager>().gridSize = 5;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }





}
