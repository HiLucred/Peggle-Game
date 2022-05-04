using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPoint;
    [SerializeField] private int point;
    
    private int _totalScore;

    private void Update()
    {
        textPoint.text = _totalScore.ToString();
    }

    public void ScorePoint()
    {
        _totalScore += point;
    }
}
