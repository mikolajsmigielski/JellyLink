using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField]
    Numbers TimeCounter;

    [SerializeField]
    Numbers ScoreCounter;
    void Start()
    {
        FindObjectOfType<GameManager>().OnRemainingTimeChange += time => TimeCounter.Value = (int)time;
        FindObjectOfType<GameManager>().OnScoreChange += score => ScoreCounter.Value = score;
    }

    
   
}
