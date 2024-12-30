using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    public event UnityAction<Obstacle> OnInVisible; // Internel Event her obstacle classý için ayrý  ve Instance üzerinden oluþuluyor 
    private float _leftEdge;
    

    private void OnBecameInvisible()
    {
        OnInVisible?.Invoke(this);
    }

    void Start()
    {
        _leftEdge = Camera.main.transform.position.x - 18f;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += Vector3.left * GameManager.Instance.GameSpeed * Time.deltaTime;


        //if(transform.position.x < _leftEdge)
        //{
           
        //    Destroy(gameObject);
        //}
    }
}

