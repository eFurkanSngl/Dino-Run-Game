using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PauseBTN : UIBTN
{
    [SerializeField] private GameObject _pauseScene;

    private void GetActivePauseScene()
    {
        _pauseScene.SetActive(true);
        Time.timeScale = 0;
    }
    protected override void OnClick()
    {
       GetActivePauseScene();
        GameUIEvents.PauseUIevents?.Invoke();
    }
}
