using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float GameDuration = 60f;

    private float remainingTime;
    public float RemainingTime
    {
        get { return remainingTime; }
        private set
        {
            remainingTime = value;
            if (remainingTime < 0f)
                OnGameEnded();


            if (OnRemainingTimeChange != null)
                OnRemainingTimeChange.Invoke(remainingTime);
        }
    }

    public event Action<float> OnRemainingTimeChange;

    private int score;
    public int Score
    {
        get { return score; }
        private set
        {
            score = value;

            if (OnScoreChange != null)
                OnScoreChange.Invoke(score);
        }
    }


    
    public event Action<int> OnScoreChange;

    void Start()
    {
        Score = 0;
        RemainingTime = GameDuration;
        StartCoroutine(TimeCounterCoroutine());

        FindObjectOfType<BlocksConnection>().OnConection += UpdateScore;
    }

    

    IEnumerator TimeCounterCoroutine()
    {
        while (true)
        {
            RemainingTime -= 1f;
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnGameEnded()
    {
        PlayerPrefs.SetInt(PlayerPrefsConst.LastGameScore, Score);

        var record = PlayerPrefs.GetInt(PlayerPrefsConst.RecordScore, 0);

        if (record < Score)
            PlayerPrefs.SetInt(PlayerPrefsConst.RecordScore, Score);
        
        FindObjectOfType<SceneChanger>().ChangeScene(ScaneName.Menu);

    }
    private void UpdateScore(int lenght)
    {
        Score += lenght;
    }
}
