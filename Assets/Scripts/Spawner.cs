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
    private WaitForSeconds _wait = new WaitForSeconds(0.5f);
    private Coroutine _spawnRoutine;

    private float _currentSpawnDelay;
    private float _minSpawnDelay = 0.2f;
    private float _spawnSpeedIncrease = 0.2f;
    private float _initialSpawnDelay = 3f;
  
    

    private void Start()
    {
        _currentSpawnDelay = _initialSpawnDelay;
        _wait = new WaitForSeconds(_currentSpawnDelay);
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
    private void StartSpawnRoutine()
    {
        if(_spawnRoutine == null)
        {
            _spawnRoutine = StartCoroutine(SpawnRoutine());
        }
    }
    
    private IEnumerator SpawnRoutine()
     {
         while (true)
         {
            SpawnObstacle();

            yield return _wait;

            //if(_currentSpawnDelay > _minSpawnDelay)
            //{
            //    _currentSpawnDelay -= _spawnSpeedIncrease;
            //}
            
         }
      }
    private void SpawnObstacle()
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
        if (GameManager.Instance.GameSpeed >= 5 || GameManager.Instance.GameSpeed <= 8)
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
