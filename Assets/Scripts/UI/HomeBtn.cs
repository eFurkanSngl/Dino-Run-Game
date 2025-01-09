using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : UIBTN
{
    private void SceneLoaded()
    {
        SceneManager.LoadScene("MainMenu");
    }

    protected override void OnClick()
    {
        SceneLoaded();
        GameUIEvents.HomeUIevents?.Invoke();
    }
}
