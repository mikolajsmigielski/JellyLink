using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUserInterface : MonoBehaviour
{
    [SerializeField]
    Numbers LastGameScore;

    [SerializeField]
    Numbers RecordScore;
    void Start()
    {
        LastGameScore.Value = PlayerPrefs.GetInt(PlayerPrefsConst.LastGameScore, 0);
        RecordScore.Value = PlayerPrefs.GetInt(PlayerPrefsConst.RecordScore, 0);
    }

    
    public void LoadGame()
    {
        SceneManager.LoadScene(ScaneName.SampleScene);
    }
}
