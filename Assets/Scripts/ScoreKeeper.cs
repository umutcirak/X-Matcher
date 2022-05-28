using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    
    [SerializeField] int scoreIncrease = 100;
    public int currentScore;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void IncrementScore(int matchSize)
    {
        int bonusMultiplier = (int)matchSize / 2;
        currentScore += matchSize * bonusMultiplier * scoreIncrease;
    }


}
