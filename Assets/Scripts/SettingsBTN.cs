using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBTN : UIBTN
{
    [SerializeField] private GameObject _settingsPanel;
    protected override void OnClick()
    {

        GetActivePanel();
        MainMenuEvents.SettingsBTN?.Invoke();
    }

    private void GetActivePanel()
    {
       _settingsPanel.SetActive(true);
    }

}
