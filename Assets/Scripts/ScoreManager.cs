using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI _gameOverPanel;
    public TextMeshProUGUI _scoreText;
    private float _score = 0;
    //private float _scoreIncrement = 3f;

  
    public float Score => _score;
    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = Mathf.FloorToInt(_score).ToString();
        }
    }
    
   
    private void Update()
    {
        UpdateScoreText();
        IncreaseScore();
    }
    private void IncreaseScore()
    {
        //_score += _scoreIncrement * Time.deltaTime;
        _score += (GameManager.Instance.GameSpeed / 2f) * Time.deltaTime;
    }

    private void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    private void GameOverPanelEnable() => _gameOverPanel.gameObject.SetActive(true);
    private void GameOverPanelDisable() => _gameOverPanel.gameObject.SetActive(false);

    private void OnEnable()
    {
        ScoreManagerEvents.ScoreEventsEnable += GameOverPanelEnable;
        ScoreManagerEvents.ScoreEventsDisable += GameOverPanelDisable;

        GameEvents.OnNewGame += ResetScore;

        UIEvents.UIHandlerUpdate += UpdateScoreText;
        UIEvents.UIHandleIncrease += IncreaseScore;
    }

    private void OnDisable()
    {
        ScoreManagerEvents.ScoreEventsEnable -= GameOverPanelEnable;
        ScoreManagerEvents.ScoreEventsDisable -= GameOverPanelDisable;

        GameEvents.OnNewGame -= ResetScore;


        UIEvents.UIHandlerUpdate -= UpdateScoreText;
        UIEvents.UIHandleIncrease -= IncreaseScore;
    }
   
    private void UnLockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel1", +1) + 1);
            PlayerPrefs.Save();
        }
    }

    private void NewLevel()
    {
        if(_score == 100)
        {
            UnLockNewLevel();
        }
    }
}
