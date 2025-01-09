using Assets.Scripts.Events;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;


public class Spawner : MonoBehaviour
{
    
   [SerializeField]private List<Obstacle> obstacles = new List<Obstacle>();
    [SerializeField] private List<GameObject> _obstaclePrefabs;
    private WaitForSeconds _wait;
    private Coroutine _spawnRoutine;

    private float _currentSpawnDelay;
    private float _minSpawnDelay = 1f;
    private float _spawnSpeedIncrease = 0.10f;
    private float _initialSpawnDelay = 5f;
    private bool _isRestart = false;
  
    

    private void Start()
    {
        _currentSpawnDelay = _initialSpawnDelay;
        StartSpawnRoutine();
        
    }
    //private void StopSpawnRoutine()
    //{
    //    if(_spawnRoutine != null)
    //    {
    //        StopCoroutine(_spawnRoutine);
    //        _spawnRoutine = null;
    //    }
    //}
    public  void StartSpawnRoutine()
    {
        if(_spawnRoutine == null)
        {
            _spawnRoutine = StartCoroutine(SpawnRoutine());
        }
    }
    private void OnRestartSpawnDelay()
    {
            _currentSpawnDelay = _initialSpawnDelay;
        
    }
    private void OnEnable()
    {
        GameEvents.OnRestart += OnRestartSpawnDelay;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= OnRestartSpawnDelay;
    }

    private IEnumerator SpawnRoutine()
     {
         while (true)
         {
           
            if (_currentSpawnDelay > _minSpawnDelay)
            {
                _currentSpawnDelay -= _spawnSpeedIncrease;
            }

            SpawnObstacle();
            _wait = new WaitForSeconds(_currentSpawnDelay);


            yield return _wait;
         }
     }

    public void SpawnObstacle()
    {

        int randomIndex = GetRandomPrefabIndex();
       // int randomIndex = UnityEngine.Random.Range(0, _obstaclePrefabs.Count);
        GameObject gameObject = Instantiate(_obstaclePrefabs[randomIndex]);

        Obstacle obstacle = gameObject.GetComponent<Obstacle>();
        obstacle.OnInVisible += OnInVisible;  // evente bir method tanýmladým
        obstacles.Add(obstacle);  // daha sonra onu listeye ekledim
            
    }


    private void OnInVisible(Obstacle arg0)
    {
        obstacles.Remove(arg0);    // paramtle ile gelenleri siliyor listeden 
        arg0.OnInVisible -= OnInVisible;  // eventi kaydýný artýk siliyoruz 
        Destroy(arg0.gameObject);  // objeleri yok ediyooruz
    }

    private int GetRandomPrefabIndex()
    {
        if (GameManager.Instance.GameSpeed >= 5 || GameManager.Instance.GameSpeed <=8)
        {
            // Ýlk 4 prefab arasýndan rastgele seçim yap
            return UnityEngine.Random.Range(0,2);
        }
        else 
        {
            // Tüm prefab'lar arasýndan rastgele seçim yap
            return UnityEngine.Random.Range(0, _obstaclePrefabs.Count);
        }
    }

}
