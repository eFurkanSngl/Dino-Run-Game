using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RetyButton : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    private UnityAction _Onclicked;


    private void Start()
    {
        _retryButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        GameEvents.OnNewGame?.Invoke();
    }

}
