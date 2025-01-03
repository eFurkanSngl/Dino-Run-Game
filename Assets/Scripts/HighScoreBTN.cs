using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreBTN : UIBTN
{
    [SerializeField] private GameObject _highScorePanel;

    protected override void OnClick()
    {
        SetActivePanel();
        MainMenuEvents.HighScoreBTN?.Invoke();
    }


    private void SetActivePanel()
    {
       _highScorePanel.SetActive(true);
    }
}
