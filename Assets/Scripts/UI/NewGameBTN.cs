using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameBTN : UIBTN
{
    [SerializeField] private GameObject _levelScene;
    protected override void OnClick()
    {
        LevelSceneActive();
        MainMenuEvents.NewGameBTN?.Invoke();
    }

    private void LevelSceneActive()
    {
        _levelScene.SetActive(true);
    }
}
