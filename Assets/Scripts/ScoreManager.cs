using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI _gameOverPanel;
    public TextMeshProUGUI _scoreText;
    private float _score = 0;
  
    public float Score => _score;
    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
    }

    private void Update()
    {
        UpdateScoreText();
        IncreaseScore();
    }
    private void IncreaseScore()
    {
        _score += GameManager.Instance.GameSpeed * Time.deltaTime;
    }

    private void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }


    private void OnEnable()
    {
        GameEvents.OnNewGame += ResetScore;

        UIEvents.UIHandler += UpdateScoreText;
        UIEvents.UIHandler += IncreaseScore;
    }

    private void OnDisable()
    {
        GameEvents.OnNewGame -= ResetScore;

        UIEvents.UIHandler -= UpdateScoreText;
        UIEvents.UIHandler -= IncreaseScore;
    }
   

}
