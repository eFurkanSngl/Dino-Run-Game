using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Ground : MonoBehaviour
{
    // public event UnityAction OnGround;  Internel Events her class için çalýþýr


    private float _speed;
    private MeshRenderer _renderer;

    private void Awake()
    {
       // GameEvents.NewGame += OnNewGame;  // Evente Methodu tanýmladýk , sabit event tek çalýþýr
        _renderer = GetComponent<MeshRenderer>();
    }
    //private void Start()
    //{
    //    OnGround += OnNewGame;
    //    OnGround?.Invoke();
    //}
    //private void OnNewGame()
    //{
    //    Debug.LogWarning("player ground");  // methodun iþlevi
       
       
    //}

    // Update is called once per frame
    void Update()
    {
        _speed = GameManager.Instance.GameSpeed / transform.localScale.x;
        _renderer.material.mainTextureOffset += Vector2.right * _speed * Time.deltaTime;
    }
}
