using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : UIBTN
{
    [SerializeField] private GameObject _pauseMenuUI;
    protected override void OnClick()
    {
        ClosePasueMenu();
        GameUIEvents.PlayUIevents?.Invoke();
    }

    private void ClosePasueMenu()
    {
        Time.timeScale = 1f;
        _pauseMenuUI.gameObject.SetActive(false);
    }

}
