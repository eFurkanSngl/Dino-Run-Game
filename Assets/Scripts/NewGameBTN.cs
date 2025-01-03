using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameBTN : UIBTN
{
    protected override void OnClick()
    {
        LoadMainScene();
        MainMenuEvents.NewGameBTN?.Invoke();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Dino-Run");
    }
}
