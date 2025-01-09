using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RetyButton : UIBTN
{

    //private UnityAction _Onclicked;
    [SerializeField] private GameObject _closeMenu;
    private void CloseMenu()
    {
        Time.timeScale = 1.0f;
        _closeMenu.SetActive(false);
    }
    protected override void OnClick()
    {
        CloseMenu();
        GameEvents.OnNewGame?.Invoke();
        GameEvents.OnRestart?.Invoke();
    }

}
