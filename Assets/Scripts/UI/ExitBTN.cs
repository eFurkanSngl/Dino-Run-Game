using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBTN : UIBTN
{

    protected override void OnClick()
    {
        LoadScene();
        MainMenuEvents.ExitBTN?.Invoke();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
